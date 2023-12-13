namespace Education.Web.Client.Models.Test;

public abstract record AnswerResult(bool IsCorrect)
{
    public sealed record ShortModel(bool IsCorrect, string Answer)
        : AnswerResult(IsCorrect);

    public sealed record SingleModel(bool IsCorrect, uint Answer)
        : AnswerResult(IsCorrect);

    public sealed record MultipleModel(bool IsCorrect, IEnumerable<uint> Answer)
        : AnswerResult(IsCorrect);

    public sealed record OrderedModel(bool IsCorrect, IEnumerable<uint> Answer)
        : AnswerResult(IsCorrect);
}
