using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;
using PollingApp.Contracts;
using Calabonga.OperationResults;

namespace PollingApp.BlazorLib;

public class PollCreateModel : ComponentBase
{
    [Inject] protected IPollService PollService { get; set; } = null!;
    public List<string> Errors { get; } = new();
    public OperationResult<SaveResult>? Result { get; set; }

    public string? QuestionText { get; set; }

    public List<AnswerInput> Answers { get; set; } = new List<AnswerInput>();

    public bool IsValid =>
        !string.IsNullOrEmpty(QuestionText)
        && QuestionText.Length > 0
        && Answers.Count is > 1 and <= 10;

    protected void AddAnswer()
    {
        Answers.Add(new AnswerInput());
    }

    protected void DeleteAnswer(AnswerInput item)
    {
        Answers.Remove(item);
    }

    protected void Validate()
    {
        var errors = ValidatePoll();

        var validationResults = errors.ToList();
        if (validationResults.Any())
        {
            Errors.AddRange(validationResults.Select(x => x.ErrorMessage).ToList()!);
        }
        else
        {
            Errors.Clear();
        }
    }

    protected async Task SaveAnswer()
    {
        Validate();
        if (Errors.Any())
        {
            return;
        }

        var cancellationTokenSource = new CancellationTokenSource();
        cancellationTokenSource.CancelAfter(5000);

        Result = await PollService.SaveAsync(QuestionText!, Answers.Select(
            x => x.Text).ToList()!, cancellationTokenSource.Token);
        if (Result.Ok)
        {
            QuestionText = null;
            Errors.Clear();
            Answers.Clear();        
        }
    }

    private IEnumerable<ValidationResult> ValidatePoll()
    {
        if (string.IsNullOrWhiteSpace(QuestionText))
        {
            yield return new ValidationResult("�� ����� ������ ��� �����������.");
        }

        if (QuestionText is { Length: > 512 or < 3 })
        {
            yield return new ValidationResult("����� ������� ��� ����������� ������ ���� ����� 3 � ����� 512 ��������.");
        }

        if (!Answers.Any())
        {
            yield return new ValidationResult("�� ������ ������ ��� �����������.");
            yield break;
        }

        if (Answers.Count < 2)
        {
            yield return new ValidationResult("��������� ����� ���� ��������� ������.");
        }

        if (Answers.Count > 10)
        {
            yield return new ValidationResult("����� ������ �� ����� 10 ��������� ������.");
        }

        foreach (var answer in Answers)
        {
            if (string.IsNullOrWhiteSpace(answer.Text))
            {
                yield return new ValidationResult("�� ����� ����� ������.");
                continue;
            }

            if (!string.IsNullOrWhiteSpace(answer.Text) && answer.Text.Length > 512)
            {
                yield return new ValidationResult($"\"{answer.Text}\" ������� �������. ����� �� ����� 512 ��������.");
                continue;
            }

            if (!string.IsNullOrWhiteSpace(answer.Text) && answer.Text.Length < 3)
            {
                yield return new ValidationResult($"\"{answer.Text}\" ������� ��������. ����� �� ����� 3 ��������.");
            }
        }
    }
}

public class AnswerInput
{
    public string? Text { get; set; }

}