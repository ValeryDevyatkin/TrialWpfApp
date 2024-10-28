using System.Windows;
using System.Windows.Controls;

namespace ValeryDzeviatkin.TrialApp.WpfClient.Views.Controls;

public partial class RegionWrapper
{
    public RegionWrapper()
    {
        InitializeComponent();
    }

    #region Orientation dependency: Orientation

    public static readonly DependencyProperty OrientationProperty =
        DependencyProperty.Register(
            nameof(Orientation),
            typeof(Orientation),
            typeof(RegionWrapper),
            new PropertyMetadata(Orientation.Vertical));

    public Orientation Orientation
    {
        get => (Orientation)GetValue(OrientationProperty);
        set => SetValue(OrientationProperty, value);
    }

    #endregion
}