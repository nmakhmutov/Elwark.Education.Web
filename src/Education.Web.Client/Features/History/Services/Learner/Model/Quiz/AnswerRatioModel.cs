namespace Education.Web.Client.Features.History.Services.Learner.Model.Quiz;

public sealed record AnswerRatioModel(uint Questions, uint Answered, uint NotAnswered, uint Correct, uint Incorrect);
