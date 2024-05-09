using FluentValidation;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Client.Features.History.Pages.DateGuessers.Test;

public sealed partial class DateGuesserForm
{
    private static Dictionary<uint, string> _months = [];
    private bool _isLoading;
    private Model _model = new(string.Empty);

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Parameter, EditorRequired]
    public required EventCallback<Model> OnAnswer { get; set; }

    [Parameter, EditorRequired]
    public required string QuestionId { get; set; }

    protected override void OnParametersSet() =>
        _model = new Model(QuestionId);

    protected override void OnInitialized() =>
        _months = new Dictionary<uint, string>
        {
            [1] = L["Month_January_Title"],
            [2] = L["Month_February_Title"],
            [3] = L["Month_March_Title"],
            [4] = L["Month_April_Title"],
            [5] = L["Month_May_Title"],
            [6] = L["Month_June_Title"],
            [7] = L["Month_July_Title"],
            [8] = L["Month_August_Title"],
            [9] = L["Month_September_Title"],
            [10] = L["Month_October_Title"],
            [11] = L["Month_November_Title"],
            [12] = L["Month_December_Title"]
        };

    private async Task OnValidSubmit()
    {
        _isLoading = true;

        try
        {
            await OnAnswer.InvokeAsync(_model);
            _model.Reset();
        }
        finally
        {
            _isLoading = false;
        }
    }

    public sealed record Model
    {
        public Model(string questionId) =>
            QuestionId = questionId;

        public int? Year { get; set; }

        public uint? Month { get; set; }

        public uint? Day { get; set; }

        public bool IsCe { get; set; } = true;

        public string QuestionId { get; }

        public void Reset()
        {
            Year = null;
            Month = null;
            Day = null;
        }

        public sealed class Validator : AbstractValidator<Model>
        {
            public Validator()
            {
                RuleFor(x => x.Year)
                    .NotNull()
                    .GreaterThan(0)
                    .LessThanOrEqualTo(9999);

                RuleFor(x => x.Month)
                    .GreaterThan(0u)
                    .LessThanOrEqualTo(12u);

                RuleFor(x => x.Day)
                    .GreaterThan(0u)
                    .LessThanOrEqualTo(31u);
            }
        }
    }
}
