using Microsoft.Extensions.Logging;
using Rowing.Application.Interfaces;

namespace Rowing.Application.CommonErrors.QueryServices;

public class CommonErrorsQueryService: ICommonErrorsQueryService
{
    private readonly ICommonErrorsRepository _commonErrorsRepo;
    private readonly ILogger<CommonErrorsQueryService> _logger;

    public CommonErrorsQueryService(ICommonErrorsRepository commonErrorsRepo, ILogger<CommonErrorsQueryService> logger)
    {
        _commonErrorsRepo = commonErrorsRepo;
        _logger = logger;
    }
}