namespace Rowing.Application.CommonErrors.CommandServices;

public interface ICommonErrorCommandService
{
    public Task UpdateCommonErrorAsync(int id, UpdateCreateCommonErrorDto dto);
}