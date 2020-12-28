using System.Collections.Generic;
using Elwark.Education.Web.Gateways.Models;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Elwark.Education.Web.Model
{
    public sealed record AnswerModel
    {
        public QuestionType QuestionType { get; init; }

        public string TextAnswer { get; set; } = string.Empty;

        public int SingleAnswer { get; set; }

        public List<int> ManyAnswer { get; set; } = new();
    }

    public sealed class ModelValidator : AbstractValidator<AnswerModel>
    {
        public ModelValidator(IStringLocalizer<App> localizer)
        {
            RuleFor(x => x.TextAnswer)
                .NotEmpty()
                .WithMessage(localizer["Test:AnswerCannotBeEmpty"])
                .When(x => x.QuestionType == QuestionType.TextAnswer);

            RuleFor(x => x.SingleAnswer)
                .NotEmpty()
                .WithMessage(localizer["Test:AnswerCannotBeEmpty"])
                .When(x => x.QuestionType == QuestionType.SingleAnswer);

            RuleFor(x => x.ManyAnswer)
                .NotEmpty()
                .WithMessage(localizer["Test:AnswerCannotBeEmpty"])
                .When(x => x.QuestionType == QuestionType.ManyAnswers || x.QuestionType == QuestionType.SortedAnswers);
        }
    }
}