using System;
using GrubGroup.Domain.Models.Logging;

namespace GrubGroup.Domain.Repositories.Logging
{
	public interface IErrorLogRepository
	{
		ErrorLog FindById(Guid errorLogId);
		long LogError(ErrorLog errorLog);
	}
}
