namespace Bokunda.Preslovitelj.Cqrs.Responses;
public record TranslateTextResponse
{
    public string TranslatedText { get; set; } = string.Empty;
    public int NumberOfCharacters { get; set; }
    public int NumberOfWords { get; set; }
}
