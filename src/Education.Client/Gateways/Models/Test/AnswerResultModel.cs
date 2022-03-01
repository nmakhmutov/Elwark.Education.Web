namespace Education.Client.Gateways.Models.Test;

public abstract record AnswerResultModel(bool IsCorrect);

public sealed record ShortAnswerResultModel(bool IsCorrect, string Answer)
    : AnswerResultModel(IsCorrect);

public sealed record SingleAnswerResultModel(bool IsCorrect, uint Answer)
    : AnswerResultModel(IsCorrect);

public sealed record MultipleAnswersResultModel(bool IsCorrect, IEnumerable<uint> Answer)
    : AnswerResultModel(IsCorrect);
