using TierApp.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace TierApp.Entity.Models
{
    public class User : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
