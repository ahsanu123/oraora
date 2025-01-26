using System.Text.Json;

namespace LearnRazor.JsonSerializerConstant;

public static class JsonConstant
{
    public static JsonSerializerOptions Options { get; set; } = new() { WriteIndented = true };
}
