using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using schoolapp.Application.Common.Models;
using schoolapp.Application.Contracts;
using schoolapp.Application.DTOs;
using schoolapp.Application.RepositoryInterfaces;

namespace schoolapp.Application.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly ILogger<SchoolService> _logger;
        public SchoolService(ILogger<SchoolService> logger, ISchoolRepository schoolRepository)
        {
            _logger = logger;
            _schoolRepository = schoolRepository;
        }
        public async Task<Result<IEnumerable<SchoolDto>>> GetSchools(CancellationToken cancellationToken)
        {
            try
            {
                var schoolsQuery = await _schoolRepository.GetSchoolsAsync(cancellationToken);
                var schools = await schoolsQuery.Select(s => new SchoolDto
                {
                    SchoolId = s.SchoolId,
                    SchoolName = s.SchoolName,
                    Country = s.Country,
                    City = s.City,
                    PostalCode = s.PostalCode,
                    Address = s.Address,
                    HomePage = s.HomePage,
                    Location = s.Location,
                    Phone = s.Phone,
                    Region = s.Region,
                    Street = s.Street,
                    ZipCode = s.ZipCode,
                    CreatedAt = s.Created
                })
                .ToListAsync( cancellationToken);
                return Result<IEnumerable<SchoolDto>>.Success(schools);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching schools");
                return Result<IEnumerable<SchoolDto>>.Failure(["Error fetching schools: " + ex.Message]);
            }
        }

        public async Task<Result<SchoolDto>> GetSchool(int schoolId, CancellationToken cancellationToken)
        {
            try
            {
                var school = await _schoolRepository.GetByIdAsync(schoolId, cancellationToken);
                return Result<SchoolDto>.Success(SchoolDto.ToSchoolDto(school));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching school");
                return Result<SchoolDto>.Failure(["Error fetching school: " + ex.Message]);
            }
        }

        public async Task<Result<SchoolDto>> PutSchool(int id, SchoolDto request, CancellationToken cancellationToken)
        {
            try
            {
                var existingSchool = await _schoolRepository.GetByIdAsync(id, cancellationToken);
                if (existingSchool == null)
                    return Result<SchoolDto>.Failure([$"School with id {id} not found"]);

                // Check for name conflicts (if name is being changed)
                if (!string.IsNullOrWhiteSpace(request.SchoolName) &&
                    request.SchoolName != existingSchool.SchoolName)
                {
                    var nameConflict = await _schoolRepository.GetByNameAsync(request.SchoolName, cancellationToken);
                    if (nameConflict != null) return Result<SchoolDto>.Failure([$"School with name '{request.SchoolName}' already exists"]);
                }

                var builder = CreateBuilderFromExisting(existingSchool);

                if (!string.IsNullOrWhiteSpace(request.SchoolName))
                    builder.WithName(request.SchoolName);

               builder.OfType(request.SchoolType);

                if (!string.IsNullOrWhiteSpace(request.Location))
                    builder.WithLocation(request.Location);

                if (!string.IsNullOrWhiteSpace(request.Email))
                    builder.WithContactInfo(
                        request.Email,
                        request.Phone ?? existingSchool.Phone,
                        request.HomePage ?? existingSchool.HomePage
                    );

                // Update address if any address fields are provided
                if (HasAddressChanges(request))
                {
                    builder.WithAddress(
                        street: request.Street ?? existingSchool.Street,
                        city: request.City ?? existingSchool.City,
                        zipCode: request.ZipCode ?? existingSchool.ZipCode,
                        postalCode: request.PostalCode ?? existingSchool.PostalCode,
                        country: request.Country ?? existingSchool.Country,
                        region: request.Region ?? existingSchool.Region
                    );
                }

                if (!string.IsNullOrWhiteSpace(request.LogoUrl))
                    builder.WithLogo(request.LogoUrl);

                // Update settings if provided
             
                    builder.WithSettings(settings => settings
                        .UseSingleName(request.UseSingleName)
                        .AsGroupOfSchools(request.IsGroupOfSchools)
                        .WithStreams(request.UseStreams)
                    );
                

                var updatedSchool = builder.Build();
                updatedSchool.SchoolId = id; 

                // Update in database
                var result = await _schoolRepository.UpdateAsync(updatedSchool);

                _logger.LogInformation("Updated school with ID: {SchoolId}", id);

                return Result<SchoolDto>.Success(SchoolDto.ToSchoolDto(result.Value));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating school");
                return Result<SchoolDto>.Failure(["Error updating school: " + ex.Message]);
            }
        }

        public async Task<Result<School>> PostSchool(SchoolDto _school, CancellationToken cancellationToken)
        {
            try
            {
                //// Check if school with same name already exists
                var existingSchool = await _schoolRepository.GetByNameAsync(_school.SchoolName, cancellationToken);
                if (existingSchool != null)
                    return Result<School>.Failure([$"School with name '{_school.SchoolName}' already exists"]);

                // Build the school using the Builder pattern
                var builder = School.CreateBuilder()
                    .WithName(_school.SchoolName)
                    .OfType(_school.SchoolType)
                    .WithLocation(_school.Location)
                    .WithContactInfo(_school.Email, _school.Phone, _school.HomePage);

                // Add address if provided
                if (!string.IsNullOrWhiteSpace(_school.Street) || !string.IsNullOrWhiteSpace(_school.City))
                {
                    builder.WithAddress(
                        street: _school.Street,
                        city: _school.City,
                        zipCode: _school.ZipCode,
                        postalCode: _school.PostalCode,
                        country: _school.Country,
                        region: _school.Region
                    );
                }

                // Add logo if provided
                if (!string.IsNullOrWhiteSpace(_school.LogoUrl))
                {
                    builder.WithLogo(_school.LogoUrl);
                }


                builder.WithSettings(settings => settings
                    .UseSingleName(_school.UseSingleName)
                    .AsGroupOfSchools(_school.IsGroupOfSchools)
                    .WithStreams(_school.UseStreams)
                );


                var school = builder.Build();

                // Save to database
                var createdSchool = await _schoolRepository.CreateAsync(school, cancellationToken);

                _logger.LogInformation("Created school with ID: {SchoolId}", createdSchool.SchoolId);

                return Result<School>.Success(createdSchool);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating school");
                return Result<School>.Failure([$"Error creating school: {ex.Message}"]);
            }
        }

        public async Task<Result<bool>> DeleteSchool(int id, CancellationToken cancellationToken)
        {
            try
            {
                var school = await _schoolRepository.GetByIdAsync(id, cancellationToken);
                if (school == null) {
                    return Result<bool>.Failure(["School not found"]);
                }
                var res = await _schoolRepository.DeleteAsync(id, cancellationToken);
                if (res.IsSuccess)
                {
                    return Result<bool>.Success(res.Value);
                }
                return Result<bool>.Failure(res.Errors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting school");
                return Result<bool>.Failure(["Error deleting school: " + ex.Message]);
            }       
        }

        private SchoolBuilder CreateBuilderFromExisting(School existing)
        {
            var builder = School.CreateBuilder()
                .WithName(existing.SchoolName)
                .OfType(existing.SchoolType)
                .WithLocation(existing.Location)
                .WithContactInfo(existing.Email, existing.Phone, existing.HomePage);

            if (!string.IsNullOrWhiteSpace(existing.Street) || !string.IsNullOrWhiteSpace(existing.City))
            {
                builder.WithAddress(
                    existing.Street,
                    existing.City,
                    existing.ZipCode,
                    existing.PostalCode,
                    existing.Country,
                    existing.Region
                );
            }

            if (!string.IsNullOrWhiteSpace(existing.Logo))
            {
                builder.WithLogo(existing.Logo);
            }

            if (existing.ExtraSettings != null)
            {
                builder.WithSettings(settings => settings
                    .UseSingleName(existing.ExtraSettings.UseSingleName)
                    .AsGroupOfSchools(existing.ExtraSettings.IsGroupOfSchools)
                    .WithStreams(existing.ExtraSettings.UseStreams)
                );
            }

            return builder;
        }

        // Helper method to check if any address field is being updated
        private static bool HasAddressChanges(SchoolDto request)
        {
            return !string.IsNullOrEmpty(request.Street) ||
                   !string.IsNullOrEmpty(request.City) ||
                   !string.IsNullOrEmpty(request.ZipCode) ||
                   !string.IsNullOrEmpty(request.PostalCode) ||
                   !string.IsNullOrEmpty(request.Country) ||
                   !string.IsNullOrEmpty(request.Region);
        }
    }

}


