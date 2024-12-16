using FluentValidation;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Client.Features.History.Pages.DateGuessers.Components;

public sealed partial class DateGuesserForm : ComponentBase
{
    private static Dictionary<uint, string> _months = [];

    private readonly IStringLocalizer<App> _localizer;
    private bool _isLoading;
    private Model _model = new(string.Empty);

    public DateGuesserForm(IStringLocalizer<App> localizer) =>
        _localizer = localizer;

    [Parameter, EditorRequired]
    public required EventCallback<Model> OnAnswer { get; set; }

    [Parameter, EditorRequired]
    public required string QuestionId { get; set; }

    protected override void OnParametersSet() =>
        _model = new Model(QuestionId);

    protected override void OnInitialized() =>
        _months = new Dictionary<uint, string>
        {
            [1] = _localizer["Month_January_Title"],
            [2] = _localizer["Month_February_Title"],
            [3] = _localizer["Month_March_Title"],
            [4] = _localizer["Month_April_Title"],
            [5] = _localizer["Month_May_Title"],
            [6] = _localizer["Month_June_Title"],
            [7] = _localizer["Month_July_Title"],
            [8] = _localizer["Month_August_Title"],
            [9] = _localizer["Month_September_Title"],
            [10] = _localizer["Month_October_Title"],
            [11] = _localizer["Month_November_Title"],
            [12] = _localizer["Month_December_Title"]
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
