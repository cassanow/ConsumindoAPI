using System.ComponentModel.DataAnnotations;

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
}