using System.Globalization;
using FluentValidation;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Client.Features.History.Pages.DateGuessers.Test;

public sealed partial class DateGuesserForm
{
    private bool _isLoading;
    private Model _model = new();

    private static IEnumerable<KeyValuePair<uint, string>> Months =>
        CultureInfo.CurrentCulture.DateTimeFormat.MonthNames
            .Select((s, i) => new KeyValuePair<uint, string>((uint)i + 1, s));

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Parameter, EditorRequired]
    public required EventCallback<Model> OnAnswer { get; set; }

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
        public int? Year { get; set; }

        public uint? Month { get; set; }

        public uint? Day { get; set; }

        public bool IsCe { get; set; } = true;

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
