using Calabonga.OperationResults;

namespace PollingApp.Contracts;

public interface IPollService
{
     Task<OperationResult<SaveResult>> SaveAsync(string questionText, List<string> answers, 
         CancellationToken cancellation);
}
