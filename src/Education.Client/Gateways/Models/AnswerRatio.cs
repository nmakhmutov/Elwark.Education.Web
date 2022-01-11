namespace Education.Client.Gateways.Models;

public sealed record AnswerRatio(uint Questions, uint Answered, uint NotAnswered, uint Correct, uint Incorrect);
