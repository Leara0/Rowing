using Rowing.Domain.Entities;

namespace Rowing.Application.Interfaces;

public interface ICommonErrorsRepository
{
    public Task<IEnumerable<CommonError>> GetAllCommonErrorsAsync();

}