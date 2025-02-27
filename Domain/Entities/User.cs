using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public DateTime CreationDate { get; set; }

        [NotMapped] public byte[] PasswordHash { get; set; }
        [NotMapped] public byte[] PasswordSalt { get; set; }
    }
}
