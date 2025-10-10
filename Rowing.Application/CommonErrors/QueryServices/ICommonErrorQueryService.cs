namespace Rowing.Application.CommonErrors.QueryServices;

public interface ICommonErrorQueryService
{
    public Task<IEnumerable<CommonErrorDto>> GetAllCommonErrorsAsync();
}