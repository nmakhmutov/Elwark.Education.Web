using Education.Web.Gateways.Models.Content;

namespace Education.Web.Gateways.Models.Test;

public abstract record TestQuestionModel(string Id, string Title, string? Image, TopicTitleModel Topic);

public sealed record ShortAnswerQuestionModel(string Id, string Title, string? Image, TopicTitleModel Topic)
    : TestQuestionModel(Id, Title, Image, Topic);

public sealed record SingleAnswerQuestionModel(string Id, string Title, string? Image, TopicTitleModel Topic, AnswerOptionModel[] Options)
    : TestQuestionModel(Id, Title, Image, Topic);

public sealed record MultipleAnswerQuestionModel(string Id, string Title, string? Image, TopicTitleModel Topic, AnswerOptionModel[] Options)
    : TestQuestionModel(Id, Title, Image, Topic);
