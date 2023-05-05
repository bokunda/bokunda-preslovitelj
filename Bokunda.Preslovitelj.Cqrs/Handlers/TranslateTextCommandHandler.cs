using Bokunda.Preslovitelj.Cqrs.Commands;
using Bokunda.Preslovitelj.Cqrs.Enums;
using Bokunda.Preslovitelj.Cqrs.Responses;
using Bokunda.Preslovitelj.Domain;
using JetBrains.Annotations;
using MediatR;

namespace Bokunda.Preslovitelj.Cqrs.Handlers;

[UsedImplicitly]
public class TranslateTextCommandHandler : IRequestHandler<TranslateTextCommand, TranslateTextResponse>
{
    private readonly PresloviteljContext _dbContext;

    public Dictionary<string, string> _charPairs = new()
    {
        { "a",  "а" },
        { "b",  "б" },
        { "v",  "в" },
        { "g",  "г" },
        { "d",  "д" },
        { "dj", "ђ" },
        { "đ",  "ђ" },
        { "e",  "е" },
        { "ž",  "ж" },
        { "z",  "з" },
        { "i",  "и" },
        { "j",  "ј" },
        { "k",  "к" },
        { "l",  "л" },
        { "lj", "љ" },
        { "m",  "м" },
        { "n",  "н" },
        { "nj", "њ" },
        { "o",  "о" },
        { "p",  "п" },
        { "r",  "р" },
        { "s",  "с" },
        { "t",  "т" },
        { "ć",  "ћ" },
        { "u",  "у" },
        { "f",  "ф" },
        { "h",  "х" },
        { "c",  "ц" },
        { "č",  "ч" },
        { "dz", "џ" },
        { "dž", "џ" },
        { "š",  "ш" },
        { "A",  "А" },
        { "B",  "Б" },
        { "V",  "В" },
        { "G",  "Г" },
        { "D",  "Д" },
        { "DJ", "Ђ" },
        { "Đ",  "Ђ" },
        { "E",  "Е" },
        { "Ž",  "Ж" },
        { "Z",  "З" },
        { "I",  "И" },
        { "J",  "Ј" },
        { "K",  "К" },
        { "L",  "Л" },
        { "LJ", "Љ" },
        { "M",  "М" },
        { "N",  "Н" },
        { "NJ", "Њ" },
        { "O",  "О" },
        { "P",  "П" },
        { "R",  "Р" },
        { "S",  "С" },
        { "T",  "Т" },
        { "Ć",  "Ћ" },
        { "U",  "У" },
        { "F",  "Ф" },
        { "H",  "Х" },
        { "C",  "Ц" },
        { "Č",  "Ч" },
        { "DZ", "Џ" },
        { "DŽ", "Џ" },
        { "Š",  "Ш" }
    };

    public TranslateTextCommandHandler(PresloviteljContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TranslateTextResponse> Handle(TranslateTextCommand request, CancellationToken cancellationToken)
    {
        var response = new TranslateTextResponse();

        var requestEntity = TranslationRequest.Create(request.Text);
        await _dbContext.AddAsync(requestEntity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        var direction = TranslationDirection.CyrillicToLatin;

        if (direction == TranslationDirection.CyrillicToLatin)
        {
            foreach (var charPair in _charPairs)
            {
                request.Text = request.Text.Replace(charPair.Value, charPair.Key);
            }
        }

        response.TranslatedText = request.Text;

        var responseEntity = TranslationResponse.Create(request.Text);
        responseEntity.Update(requestEntity.Id);
        await _dbContext.AddAsync(responseEntity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);



        return response;
    }
}
