namespace Elwark.Education.Web.Gateways.Models.TestConclusion
{
    public sealed record AnswerConclusion(
        string QuestionId,
        string? Title,
        bool IsAnswered,
        uint Correct,
        uint Incorrect
    );
}