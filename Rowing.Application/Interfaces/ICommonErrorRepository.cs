using Rowing.Domain.Entities;

namespace Rowing.Application.Interfaces;

public interface ICommonErrorRepository
{
    public Task<IEnumerable<CommonError>> GetAllCommonErrorsAsync();
    public Task<CommonError?> GetCommonErrorByIdAsync(int id);
    public Task<int> UpdateCommonErrorAsync(CommonError model);
    public Task<int> CreateCommonErrorsAsync(CommonError model);

}