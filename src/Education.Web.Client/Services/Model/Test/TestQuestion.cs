using Education.Web.Client.Services.Model.Content;

namespace Education.Web.Client.Services.Model.Test;

public abstract record TestQuestion(string Id, string Title, string? Image, TopicTitleModel Topic)
{
    public sealed record ShortModel(string Id, string Title, string? Image, TopicTitleModel Topic)
        : TestQuestion(Id, Title, Image, Topic);

    public sealed record SingleModel(string Id, string Title, string? Image, TopicTitleModel Topic, AnswerOption[] Options)
        : TestQuestion(Id, Title, Image, Topic);

    public sealed record MultipleModel(string Id, string Title, string? Image, TopicTitleModel Topic, AnswerOption[] Options)
        : TestQuestion(Id, Title, Image, Topic);
}
