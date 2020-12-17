namespace Elwark.Education.Web.Gateways.Models
{
    public sealed record AnswerRatio(int Questions, int Answered, int NotAnswered, int Correct, int Incorrect);
}