using System.ComponentModel.DataAnnotations;

namespace UserRegister.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public List<Phone> Phones { get; set; } = new();
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime Modified { get; set; } = DateTime.UtcNow;
        public DateTime LastLogin { get; set; } = DateTime.UtcNow;
        public string Token { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }

    public class Phone
    {
        [Key]
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public string CityCode { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;
    }
}
