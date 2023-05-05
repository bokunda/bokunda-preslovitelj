using Bokunda.Preslovitelj.Cqrs.Enums;
using Bokunda.Preslovitelj.Cqrs.Responses;
using MediatR;

namespace Bokunda.Preslovitelj.Cqrs.Commands;
public record TranslateTextCommand : IRequest<TranslateTextResponse>
{
    public string Text { get; set; } = string.Empty;
    public TranslationDirection? Direction { get; set; }
}
