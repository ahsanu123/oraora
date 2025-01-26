using System.Text.Json;

namespace Oraora.Constant;

public static class JsonConstant
{
    public static JsonSerializerOptions Options { get; set; } = new() { WriteIndented = true };
}
