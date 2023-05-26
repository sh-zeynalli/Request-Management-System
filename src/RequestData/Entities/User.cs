using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestData.Entities;

public class User
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public byte[]? PasswordHash { get; set; }
    public byte[]? PasswordSalt { get; set; }
    public UserRole? Role { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public User? CreatedBy { get; set; }
    public int CreatedById {get; set;}
    public int UserRoleId {get; set;}
}
