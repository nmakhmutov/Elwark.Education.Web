namespace Education.Web.Client.Services.Model.Test;

public abstract record AnswerResult(bool IsCorrect)
{
    public sealed record ShortModel(bool IsCorrect, string Answer)
        : AnswerResult(IsCorrect);

    public sealed record SingleModel(bool IsCorrect, uint Answer)
        : AnswerResult(IsCorrect);

    public sealed record MultipleModel(bool IsCorrect, IEnumerable<uint> Answer)
        : AnswerResult(IsCorrect);
}
