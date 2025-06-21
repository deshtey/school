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
        public async Task<IEnumerable<SchoolDto>?> GetSchools(CancellationToken cancellationToken)
        {
            try
            {
                var schools = await _schoolRepository.GetAllSchoolsAsync(cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
    
            //return await _context.Schools.Select(s => new SchoolDto
            //{
            //    SchoolId = s.SchoolId,
            //    SchoolName = s.SchoolName,
            //    Country = s.Country,
            //    City = s.City,
            //    PostalCode = s.PostalCode,
            //    Address = s.Address,
            //    HomePage = s.HomePage,
            //    Location = s.Location,
            //    Phone = s.Phone,
            //    Region = s.Region,
            //    Street = s.Street,
            //    ZipCode = s.ZipCode,
            //    CreatedAt = s.Created
            //})
            //.ToListAsync();
        }

        public async Task<School?> GetSchool(int schoolId, CancellationToken cancellationToken)
        {
            try
            {
                var school = await _schoolRepository.GetByIdAsync(schoolId, cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
            //if (_context.Schools == null)
            //{
            //    return null;
            //}
            //var School = await _context.Schools.FindAsync(id);

            //if (School == null)
            //{
            //    return null;
            //}
            //return School;
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

                if (request.SchoolType.HasValue)
                    builder.WithType(request.SchoolType.Value);

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

                if (!string.IsNullOrWhiteSpace(request.Logo))
                    builder.WithLogo(request.Logo);

                // Update settings if provided
                if (request.Settings != null)
                {
                    builder.WithSettings(settings => settings
                        .UseSingleName(request.Settings.UseSingleName)
                        .AsGroupOfSchools(request.Settings.IsGroupOfSchools)
                        .WithStreams(request.Settings.UseStreams)
                    );
                }

                var updatedSchool = builder.Build();
                updatedSchool.SchoolId = id; // Preserve the ID

                // Update in database
                var result = await _schoolRepository.UpdateAsync(updatedSchool);

                _logger.LogInformation("Updated school with ID: {SchoolId}", id);

                return Ok(result);
            }
            catch (Exception)
            {

                throw;
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

        public async Task<bool> DeleteSchool(int id, CancellationToken cancellationToken)
        {
            if (_context.Schools == null)
            {
                return false;
            }
            var School = await _context.Schools.FindAsync(id);
            if (School == null)
            {
                return true;
            }

            _context.Schools.Remove(School);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
        private bool SchoolExists(int id)
        {
            return (_context.Schools?.Any(e => e.SchoolId == id)).GetValueOrDefault();
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

}
