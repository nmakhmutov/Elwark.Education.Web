using System.Text;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Primitives;

namespace Education.Web.Gateways;

public readonly struct QueryString : IEquatable<QueryString>
{
    public static readonly QueryString Empty = new(string.Empty);

    public QueryString(string? value)
    {
        if (!string.IsNullOrEmpty(value) && value[0] != '?')
            throw new ArgumentException(@"The leading '?' must be included for a non-empty query.", nameof(value));

        Value = value?.Replace("#", "%23");
    }

    public string? Value { get; }

    public bool HasValue =>
        !string.IsNullOrEmpty(Value);

    public override string ToString() =>
        Value ?? string.Empty;

    public static QueryString Create(string name, string value)
    {
        if (!string.IsNullOrEmpty(value))
            value = UrlEncoder.Default.Encode(value);

        return new QueryString($"?{UrlEncoder.Default.Encode(name)}={value}");
    }

    public static QueryString Create(IEnumerable<KeyValuePair<string, string?>> parameters)
    {
        var builder = new StringBuilder();
        var first = true;
        foreach (var (key, value) in parameters)
        {
            AppendKeyValuePair(builder, key, value, first);
            first = false;
        }

        return new QueryString(builder.ToString());
    }

    public static QueryString Create(IEnumerable<KeyValuePair<string, StringValues>> parameters)
    {
        var builder = new StringBuilder();
        var first = true;

        foreach (var (key, values) in parameters)
        {
            if (StringValues.IsNullOrEmpty(values))
            {
                AppendKeyValuePair(builder, key, null, first);
                first = false;
                continue;
            }

            foreach (var value in values)
            {
                AppendKeyValuePair(builder, key, value, first);
                first = false;
            }
        }

        return new QueryString(builder.ToString());
    }

    public QueryString Add(QueryString other)
    {
        if (!HasValue || Value!.Equals("?", StringComparison.Ordinal))
            return other;

        if (!other.HasValue || other.Value!.Equals("?", StringComparison.Ordinal))
            return this;

        // ?name1=value1 Add ?name2=value2 returns ?name1=value1&name2=value2
        return new QueryString(string.Concat(Value, "&", other.Value.AsSpan(1)));
    }

    public QueryString Add(string name, string value)
    {
        if (!HasValue || Value!.Equals("?", StringComparison.Ordinal))
            return Create(name, value);

        var builder = new StringBuilder(Value);
        AppendKeyValuePair(builder, name, value, false);

        return new QueryString(builder.ToString());
    }

    public bool Equals(QueryString other)
    {
        if (!HasValue && !other.HasValue)
            return true;

        return string.Equals(Value, other.Value, StringComparison.Ordinal);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
            return !HasValue;

        return obj is QueryString queryString && Equals(queryString);
    }

    public override int GetHashCode() =>
        string.IsNullOrEmpty(Value) ? 0 : Value!.GetHashCode();

    public static bool operator ==(QueryString left, QueryString right) =>
        left.Equals(right);

    public static bool operator !=(QueryString left, QueryString right) =>
        !left.Equals(right);

    public static QueryString operator +(QueryString left, QueryString right) =>
        left.Add(right);

    private static void AppendKeyValuePair(StringBuilder builder, string key, string? value, bool first)
    {
        builder.Append(first ? '?' : '&');
        builder.Append(UrlEncoder.Default.Encode(key));
        builder.Append('=');

        if (!string.IsNullOrEmpty(value))
            builder.Append(UrlEncoder.Default.Encode(value));
    }
}
