using Microsoft.AspNetCore.Components;

namespace PollingApp.BlazorLib;

public class PollCreateModel : ComponentBase
{
    public string? QuestionText { get; set; }

    public List<string> Answers { get; set; } = new ();

    public bool IsValid =>
        !string.IsNullOrEmpty(QuestionText)
        && QuestionText.Length> 0
        && Answers.Count is > 1 and <= 10;

    protected void Answer()
    {
        Answers.Add(string.Empty);
    }
}