using System.Globalization;
using System.Windows.Data;

namespace DddCleanArchitecture.Converters;

/// <summary>
/// Converter to multiply a <see cref="double"/> by a factor.
/// </summary>
public sealed class MultiplyConverter : IValueConverter
{
    public double Factor { get; set; } = 1.0;

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        value is double d ? d * Factor : value;

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        value is double d ? d / Factor : value;
}