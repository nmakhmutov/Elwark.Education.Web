using Education.Client.Extensions;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Education.Client.Shared.Components.Labels;

public sealed partial class DifferenceLabel
{
    private Color _color;
    private string? _icon;
    private string? _value;

    [Parameter, EditorRequired]
    public double Difference { get; set; }

    protected override void OnParametersSet() =>
        (_value, _icon, _color) = Difference switch
        {
            < 0 => ($"{Difference.ToMetric("N1")}%", Icons.Material.Outlined.ArrowDownward, Color.Error),
            > 0 => ($"+{Difference.ToMetric("N1")}%", Icons.Material.Outlined.ArrowUpward, Color.Success),
            _ => ($"{Difference.ToMetric("N1")}%", Icons.Material.Outlined.ArrowBack, Color.Surface)
        };
}
