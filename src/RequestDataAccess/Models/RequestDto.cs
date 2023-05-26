using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestDataAccess.Models;

public class RequestDto
{
    public int Id { get; set; }
    public int FromUserId { get; set; }
    public string Header { get; set; }
    public string Body { get; set; }
    public int CategoryId { get; set; }
    public int RequestStatusId { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Username { get; set; }
    public string CategoryName { get; set; }
    
}
