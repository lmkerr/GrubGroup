using GrubGroup.Domain.Models.Logging;

namespace GrubGroup.Domain.Services.Logging
{
	public interface IErrorLogService
	{
		long LogError(ErrorLog errorLog);
	}
}
