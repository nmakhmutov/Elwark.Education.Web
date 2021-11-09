using Education.Client.Gateways.Models.Content;

namespace Education.Client.Gateways.Models.Test;

public sealed record TestQuestion(
    string Id,
    QuestionType Type,
    string Title,
    string? Image,
    bool IsCompleted,
    bool CanAnswerAgain,
    TopicTitle Topic,
    AnswerOption[] Options
);
