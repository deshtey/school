public class School : BaseAuditableEntity
{
    public int SchoolId { get; set; }
    public string SchoolName { get; set; }
    public SchoolTypes SchoolType { get; set; }
    public string Location { get; set; }
    public string Logo { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? ZipCode { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public string? Region { get; set; }
    public string Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? HomePage { get; set; } = string.Empty;
    
    // Additional school information
    public string? Motto { get; set; }
    public string? VisionStatement { get; set; }
    public string? MissionStatement { get; set; }
    public string? AccreditationInfo { get; set; }
    public string? BankAccountNumber { get; set; }
    public string? BankName { get; set; }
    public string? RegistrationNumber { get; set; }
    
    public SchoolSetting ExtraSettings { get; set; }

    public static SchoolBuilder CreateBuilder() => new SchoolBuilder();
}

public class SchoolBuilder
{
    private readonly School _school;
    private SchoolSettingBuilder _settingBuilder;

    public SchoolBuilder()
    {
        _school = new School
        {
            SchoolType = SchoolTypes.Primary,
            Country = "Kenya",
            HomePage = string.Empty
        };
        _settingBuilder = new SchoolSettingBuilder();
    }

    public SchoolBuilder WithName(string name)
    {
        _school.SchoolName = name;
        return this;
    }

    public SchoolBuilder OfType(SchoolTypes type)
    {
        _school.SchoolType = type;
        _settingBuilder.WithSchoolType(type);
        return this;
    }

    public SchoolBuilder WithLocation(string location)
    {
        _school.Location = location;
        return this;
    }

    public SchoolBuilder WithAddress(string? street = null, string? city = null,
        string? zipCode = null, string? postalCode = null, string? country = null, string? region = null)
    {
        _school.Street = street;
        _school.City = city;
        _school.ZipCode = zipCode;
        _school.PostalCode = postalCode;
        _school.Country = country ?? _school.Country;
        _school.Region = region;
        _school.Address = $"{street}, {city}, {region}, {country ?? _school.Country}".Trim(' ', ',');
        return this;
    }

    public SchoolBuilder WithContactInfo(string email, string? phone = null, string? homePage = null)
    {
        _school.Email = email;
        _school.Phone = phone;
        _school.HomePage = homePage ?? string.Empty;
        return this;
    }

    public SchoolBuilder WithLogo(string logo)
    {
        _school.Logo = logo;
        return this;
    }
    
    public SchoolBuilder WithAdditionalInfo(string? motto = null, string? visionStatement = null, 
        string? missionStatement = null, string? accreditationInfo = null, 
        string? bankAccountNumber = null, string? bankName = null, string? registrationNumber = null)
    {
        _school.Motto = motto;
        _school.VisionStatement = visionStatement;
        _school.MissionStatement = missionStatement;
        _school.AccreditationInfo = accreditationInfo;
        _school.BankAccountNumber = bankAccountNumber;
        _school.BankName = bankName;
        _school.RegistrationNumber = registrationNumber;
        return this;
    }

    public SchoolBuilder WithSettings(Action<SchoolSettingBuilder> configureSettings)
    {
        configureSettings(_settingBuilder);
        return this;
    }

    public School Build()
    {
        _school.ExtraSettings = _settingBuilder.Build();
        _school.ExtraSettings.School = _school;
        return _school;
    }
}

public class SchoolSettingBuilder
{
    private readonly SchoolSetting _setting;

    public SchoolSettingBuilder()
    {
        _setting = new SchoolSetting
        {
            SchoolType = SchoolTypes.Primary,
            UseSingleName = false,
            IsGroupOfSchools = false,
            UseStreams = true
        };
    }

    public SchoolSettingBuilder WithSchoolType(SchoolTypes type)
    {
        _setting.SchoolType = type;
        return this;
    }

    public SchoolSettingBuilder UseSingleName(bool useSingleName = true)
    {
        _setting.UseSingleName = useSingleName;
        return this;
    }

    public SchoolSettingBuilder AsGroupOfSchools(bool isGroup = true)
    {
        _setting.IsGroupOfSchools = isGroup;
        return this;
    }

    public SchoolSettingBuilder WithStreams(bool useStreams = true)
    {
        _setting.UseStreams = useStreams;
        return this;
    }

    internal SchoolSetting Build() => _setting;
}

public class SchoolSetting
{
    public int Id { get; set; }
    public int ParentSchoolId { get; set; }
    public SchoolTypes SchoolType { get; set; }
    public bool UseSingleName { get; set; }
    public bool IsGroupOfSchools { get; set; }
    public bool UseStreams { get; set; }
    public School School { get; set; }
}

public enum SchoolTypes
{
    Primary,
    Secondary,
    International,
    Technical,
    University
}