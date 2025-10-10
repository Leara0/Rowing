using Rowing.Domain.Entities;

namespace Rowing.Application.Interfaces;

public interface ICommonErrorRepository
{
    public Task<IEnumerable<CommonError>> GetAllCommonErrorsAsync();
    public Task<CommonError?> GetCommonErrorById(int id);

}