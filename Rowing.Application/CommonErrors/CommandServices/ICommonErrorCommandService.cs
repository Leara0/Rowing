namespace Rowing.Application.CommonErrors.CommandServices;

public interface ICommonErrorCommandService
{
    public Task UpdateCommonErrorsAsync(int id, UpdateCreateCommonErrorDto dto);
    public Task<int> CreateCommonErrorsAsync(UpdateCreateCommonErrorDto dto);
}