namespace Bokunda.Preslovitelj.Domain;
public class TranslationRequest : BaseEntity
{
    public string Text { get; set; } = string.Empty;
    public virtual TranslationResponse TranslationResponse { get; set; } = null!;

    public static TranslationRequest Create(string text)
        => new()
        {
            Text = text
        };
}

