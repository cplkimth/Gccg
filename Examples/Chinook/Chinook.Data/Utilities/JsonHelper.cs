#region
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
#endregion

namespace Chinook.Data.Utilities;

public class JsonHelper
{
    public static JsonSerializerOptions DefaultOptions { get; } = new()
    {
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
    };
}