using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class User
{
    [Key]
    public int Id { get; private set; }

    [Required]
    [StringLength(100)]
    public string Email { get; private set; }

    [Required]
    [StringLength(100)]
    public string PasswordHash { get; private set; }

    private User() { }

    public User(string email, string passwordHash)
    {
        Email = email;
        PasswordHash = passwordHash;
    }
    
    public void SetPasswordHash(string hashedPassword)
    {
        PasswordHash = hashedPassword;
    }
}
