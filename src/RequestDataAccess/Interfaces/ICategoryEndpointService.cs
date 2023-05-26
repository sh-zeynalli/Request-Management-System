using RequestData.Entities;

namespace RequestDataAccess.Interfaces;

public interface ICategoryEndpointService
{
    List<Category> ListAsync();
}