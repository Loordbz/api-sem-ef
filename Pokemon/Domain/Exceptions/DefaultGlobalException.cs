using System.Text.Json.Serialization;

namespace Domain.Exceptions;

public class DefaultGlobalException
{
    [JsonPropertyName("data")]
    public string? Data { get; init; }

    [JsonPropertyName("success")]
    public bool Success { get; init; }

    [JsonPropertyName("notifications")]
    public string? Notification { get; init; }
}