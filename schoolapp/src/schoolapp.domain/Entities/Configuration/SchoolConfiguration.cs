using System.ComponentModel.DataAnnotations;
using schoolapp.Domain.Common;

namespace schoolapp.Domain.Entities.Configuration
{
    public class SchoolConfiguration : BaseAuditableEntity
    {
        [Required]
        [StringLength(100)]
        public string ConfigKey { get; set; }

        [Required]
        [StringLength(500)]
        public string ConfigValue { get; set; }

        [Required]
        [StringLength(50)]
        public string ConfigType { get; set; } // "string", "int", "bool", "decimal"

        [Required]
        public int SchoolId { get; set; }

        public virtual School School { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public bool IsSystemConfig { get; set; } = false;

        public T GetTypedValue<T>()
        {
            return (T)Convert.ChangeType(ConfigValue, typeof(T));
        }

        public void SetTypedValue<T>(T value)
        {
            ConfigValue = value?.ToString() ?? "";
            ConfigType = typeof(T).Name.ToLower();
        }
    }
}