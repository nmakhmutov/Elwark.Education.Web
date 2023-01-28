using Education.Web.Client.Extensions;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Education.Web.Client.Components.Elements.Label;

public sealed partial class DifferenceLabel
{
    private string? _value;
    private string? _icon;
    private Color _color;

    [Parameter, EditorRequired]
    public double Difference { get; set; }

    protected override void OnParametersSet() =>
        (_value, _icon, _color) = Difference switch
        {
            < 0 => ($"{Difference.ToReadable()}%", Icons.Material.Outlined.ArrowDownward, Color.Error),
            > 0 => ($"+{Difference.ToReadable()}%", Icons.Material.Outlined.ArrowUpward, Color.Success),
            _ => ($"{Difference.ToReadable()}%", Icons.Material.Outlined.ArrowBack, Color.Surface)
        };
}
