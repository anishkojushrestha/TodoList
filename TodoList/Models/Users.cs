using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? lastName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public string? Password { get; set; }
    }
}
