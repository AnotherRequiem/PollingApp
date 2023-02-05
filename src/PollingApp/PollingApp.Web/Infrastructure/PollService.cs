using Calabonga.UnitOfWork;
using Calabonga.OperationResults;
using PollingApp.Contracts;
using PollingApp.Entities;

namespace PollingApp.Web.Infrastructure;

public class PollService : IPollService
{
    private readonly IUnitOfWork _unitOfWork;

    public PollService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;   
    }

    public async Task<OperationResult<SaveResult>> SaveAsync(string questionText, List<string> answers,
        CancellationToken cancellationToken)
    {
        var answerForPoll = answers.Select(x => new Answer(Guid.Empty, x)).ToList();
        var poll = new Poll(questionText, answerForPoll);

        var repository = _unitOfWork.GetRepository<Poll>();

        await repository.InsertAsync(poll, cancellationToken);
        await _unitOfWork.SaveChangesAsync();

        var operation = OperationResult.CreateResult<SaveResult>();

        if(!_unitOfWork.LastSaveChangesResult.IsOk)
        {
            operation.AddError(_unitOfWork.LastSaveChangesResult.Exception ??
                new InvalidOperationException());
            return operation;
        }

        operation.Result = new SaveResult
        {
            TotalPolls = await repository.CountAsync(null, cancellationToken)
        };
        operation.AddSuccess("New poll successfully saved");
        return operation;
    }
} 