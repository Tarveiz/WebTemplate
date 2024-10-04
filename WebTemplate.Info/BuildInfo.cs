using System.Text.Json.Serialization;

namespace WebTemplate.Info;
public record BuildInfo(
    [property: JsonPropertyName("is-develop")] bool? IsDevelop,
    [property: JsonPropertyName("commit-sha")] string? CommitSHA,
    [property: JsonPropertyName("git-version")] string? GitVersion,
    [property: JsonPropertyName("build_date")] DateTimeOffset? BuildDate,
    [property: JsonPropertyName("build_id")] int? BuildId,
    [property: JsonPropertyName("app-name")] string? AppName);
