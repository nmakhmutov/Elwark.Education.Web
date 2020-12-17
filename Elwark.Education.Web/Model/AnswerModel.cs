using System;
using Elwark.Education.Web.Gateways.Models;
using FluentValidation;

namespace Elwark.Education.Web.Model
{
    public sealed record AnswerModel
    {
        public QuestionType QuestionType { get; init; }

        public AnswerState State { get; set; }

        public bool? IsAnswerCorrect { get; set; }

        public string Value { get; set; } = string.Empty;

        public string CorrectValue { get; set; } = string.Empty;

        public string[] Values { get; set; } = Array.Empty<string>();

        public string[] CorrectValues { get; set; } = Array.Empty<string>();

        public bool IsDisabled => State == AnswerState.Answering;
    }
    
    public sealed class ModelValidator : AbstractValidator<AnswerModel>
    {
        public ModelValidator()
        {
            RuleFor(x => x.Value)
                .NotEmpty()
                .When(x => x.QuestionType == QuestionType.NoOptions || x.QuestionType == QuestionType.SingleOption);

            RuleFor(x => x.Values)
                .NotEmpty()
                .When(x => x.QuestionType == QuestionType.ManyOptions || x.QuestionType == QuestionType.OrderedOptions);
        }
    }
}