using System.Windows;

namespace ValeryDzeviatkin.TrialApp.WpfClient.Theme;

internal static class UiConstants
{
    public const int OutterThicknessBase = 20;
    public const int InnerThicknessBase = 10;

    public static readonly GridLength OutterThicknessForGrid = new(OutterThicknessBase);
    public static readonly GridLength InnerThicknessForGrid = new(InnerThicknessBase);

    public static readonly Thickness OutterThickness = new(OutterThicknessBase);
    public static readonly Thickness InnerThickness = new(InnerThicknessBase);

    public static readonly CornerRadius CornerRadius = new(4);
}