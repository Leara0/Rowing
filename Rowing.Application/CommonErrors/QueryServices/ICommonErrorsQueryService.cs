namespace Rowing.Application.CommonErrors.QueryServices;

public interface ICommonErrorsQueryService
{
    public Task<IEnumerable<CommonErrorsDto>> GetAllCommonErrorsAsync();
}