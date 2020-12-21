using System;
using Elwark.Education.Web.Gateways.Models;
using FluentValidation;

namespace Elwark.Education.Web.Model
{
    public sealed record AnswerModel
    {
        public QuestionType QuestionType { get; init; }

        public string TextAnswer { get; set; } = string.Empty;

        public int SingleAnswer { get; set; }

        public int[] ManyAnswer { get; set; } = Array.Empty<int>();
    }

    public sealed class ModelValidator : AbstractValidator<AnswerModel>
    {
        public ModelValidator()
        {
            RuleFor(x => x.TextAnswer)
                .NotEmpty()
                .When(x => x.QuestionType == QuestionType.TextAnswer);

            RuleFor(x => x.SingleAnswer)
                .NotEmpty()
                .When(x => x.QuestionType == QuestionType.SingleAnswer);

            RuleFor(x => x.ManyAnswer)
                .NotEmpty()
                .When(x => x.QuestionType == QuestionType.ManyAnswers || x.QuestionType == QuestionType.SortedAnswers);
        }
    }
}