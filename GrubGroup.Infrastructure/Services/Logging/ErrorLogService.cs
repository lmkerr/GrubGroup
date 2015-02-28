using GrubGroup.Domain.Models.Logging;
using GrubGroup.Domain.Repositories.Logging;
using GrubGroup.Domain.Services.Logging;

namespace GrubGroup.Infrastructure.Services.Logging
{
	public class ErrorLogService : IErrorLogService
	{
		private readonly IErrorLogRepository _errorLogRepository;
		public ErrorLogService(IErrorLogRepository errorLogRepository)
		{
			_errorLogRepository = errorLogRepository;
		}

		public long LogError(ErrorLog errorLog)
		{
			return _errorLogRepository.LogError(errorLog);
		}
	}
}
