using System.ComponentModel.DataAnnotations;
using ConsumirApi.Enum;

namespace ConsumirApi.Model;

public class User
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    public Role Role { get; set; }  
}