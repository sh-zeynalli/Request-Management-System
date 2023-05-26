using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestData.Entities;

public class Request
{
    public int Id { get; set; }
    public int FromUserId { get; set; }
    public User? FromUser { get; set; }
    public string Header { get; set; }
    public string Body { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public int RequestStatusId { get; set; }
    public RequestStatus? Status { get; set; }
    public DateTime CreatedAt { get; set; }
    
}
