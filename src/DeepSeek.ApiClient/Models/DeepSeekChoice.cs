using System.Text.Json.Serialization;

namespace DeepSeek.ApiClient.Models;
public class DeepSeekChoice
{
  public int Index { get; set; }
 
  public DeepSeekMessage? Message { get; set; }

  [JsonPropertyName("finish_reason")]
  public string FinishReason { get; set; } = string.Empty;
}
