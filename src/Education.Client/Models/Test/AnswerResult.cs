namespace Education.Client.Models.Test;

public abstract record AnswerResult(bool IsCorrect)
{
    public sealed record TextModel(bool IsCorrect, string Answer)
        : AnswerResult(IsCorrect);

    public sealed record SingleModel(bool IsCorrect, uint Answer)
        : AnswerResult(IsCorrect);

    public sealed record MultiModel(bool IsCorrect, IEnumerable<uint> Answer)
        : AnswerResult(IsCorrect);

    public sealed record OrderingModel(bool IsCorrect, IEnumerable<uint> Answer)
        : AnswerResult(IsCorrect);
}
