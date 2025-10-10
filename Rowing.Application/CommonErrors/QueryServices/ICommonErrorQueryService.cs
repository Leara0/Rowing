namespace Rowing.Application.CommonErrors.QueryServices;

public interface ICommonErrorQueryService
{
    public Task<IEnumerable<CommonErrorDto>> GetAllCommonErrorsAsync();
    public Task<CommonErrorDto?> GetCommonErrorByIdAsync(int id);
}