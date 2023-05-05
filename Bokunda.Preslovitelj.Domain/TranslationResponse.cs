namespace Bokunda.Preslovitelj.Domain;
public class TranslationResponse : BaseEntity
{
    public string Text { get; set; } = string.Empty;
    public long TranslationRequestId { get; set; }
    public virtual TranslationRequest TranslationRequest { get; set; } = null!;

    public static TranslationResponse Create(string text)
        => new()
        {
            Text = text
        };

    public void Update(long translationRequestId)
    {
        TranslationRequestId = translationRequestId;
    }
}