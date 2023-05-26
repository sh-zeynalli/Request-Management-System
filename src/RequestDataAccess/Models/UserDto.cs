using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestDataAccess.Models;

public class UserDto
{
    public int Id { get; set; }
    public string Username { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public int RoleId { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public int CreatedById { get; set; }
}
