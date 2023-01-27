using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace PollingApp.BlazorLib;

public class PollCreateModel : ComponentBase
{
    public List<string> Errors { get; } = new();

    public string? QuestionText { get; set; } = "How are u today?";

    public List<AnswerInput> Answers { get; set; } = new()
    {
        new AnswerInput{Text = "Fine" },
        new AnswerInput{Text = "Not bad" },
        new AnswerInput{Text = "Awesome" },
        new AnswerInput{Text = "Not god at all" },
        new AnswerInput{Text = "Alright" }
    };

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

    protected Task SaveAnswer()
    {
        Validate();
        if (Errors.Any())
        {
            return Task.CompletedTask;
        }

        // save to DB

        return Task.CompletedTask;
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