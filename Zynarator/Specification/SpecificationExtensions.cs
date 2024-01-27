using DotnetGenerator.Zynarator.Criteria;
using JasperFx.Core;

namespace DotnetGenerator.Zynarator.Specification;

public static class SpecificationExtensions
{
    public static bool IsNotNullOrEmpty(this string value)
        => !string.IsNullOrEmpty(value);

    public static bool In<T>(this T value, IEnumerable<T>? values)
        => values?.Contains(value) ?? false;

    public static bool NotIn<T>(this T value, IEnumerable<T>? values)
        => !value.In(values);
    
    // string
    public static bool EqualsString(this string? colValue, string? value)
    {
        return value is null || colValue == value;
    }
    
    public static bool ContainsString(this string? colValue, string? value)
    {
        return value is null || colValue!.ContainsIgnoreCase(value);
    }

    // decimal
    public static bool EqualsDecimal(this decimal? colValue, string? value) =>
        !decimal.TryParse(value, out var parsed) || colValue == parsed;

    public static bool GreaterThen(this decimal? colValue, string? valueMin) =>
        !decimal.TryParse(valueMin, out var parsedMin) || colValue >= parsedMin;

    public static bool LessThen(this decimal? colValue, string? valueMax) =>
        !decimal.TryParse(valueMax, out var parsedMin) || colValue >= parsedMin;

    // long
    public static bool EqualsDecimal(this long? colValue, string? value) =>
        !long.TryParse(value, out var parsed) || colValue == parsed;

    public static bool GreaterThen(this long? colValue, string? valueMin) =>
        !long.TryParse(valueMin, out var parsedMin) || colValue >= parsedMin;

    public static bool LessThen(this long? colValue, string? valueMax) =>
        !long.TryParse(valueMax, out var parsedMin) || colValue >= parsedMin;

    // int
    public static bool EqualsInt(this int? colValue, string? value) =>
        !int.TryParse(value, out var parsed) || colValue == parsed;

    public static bool GreaterThen(this int? colValue, string? valueMin) =>
        !int.TryParse(valueMin, out var parsedMin) || colValue >= parsedMin;

    public static bool LessThen(this int? colValue, string? valueMax) =>
        !int.TryParse(valueMax, out var parsedMin) || colValue >= parsedMin;

    // int
    public static bool EqualsDouble(this double? colValue, string? value) =>
        !double.TryParse(value, out var parsed) || colValue!.Value.ApproximatelyEquals(parsed);

    public static bool GreaterThen(this double? colValue, string? valueMin) =>
        !double.TryParse(valueMin, out var parsedMin) || colValue >= parsedMin;

    public static bool LessThen(this double? colValue, string? valueMax) =>
        !double.TryParse(valueMax, out var parsedMin) || colValue >= parsedMin;

    // datetime
    public static bool EqualsDate(this DateTime? colValue, string? value) =>
        !DateTime.TryParse(value, out var parsed) || colValue == parsed;

    public static bool GreaterThen(this DateTime? colValue, string? valueMin) =>
        !DateTime.TryParse(valueMin, out var parsedMin) || colValue >= parsedMin;

    public static bool LessThen(this DateTime? colValue, string? valueMax) =>
        !DateTime.TryParse(valueMax, out var parsedMin) || colValue >= parsedMin;
    
    // list
    public static IEnumerable<long> Ids<TProp>(this List<TProp>? list) where TProp : BaseCriteria =>
        list is null ?
            new List<long>() : 
            list.Map(e => e.Id!.Value).ToList();

    private static bool ApproximatelyEquals(this double a, double b, double epsilon = 0.000001) => Math.Abs(a - b) < epsilon;
}