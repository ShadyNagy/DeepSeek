using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DeepSeek.ApiClient.Models;
public class DeepSeekRequest
{
  public string Model { get; set; } = string.Empty;
  public List<DeepSeekMessage> Messages { get; set; } = new();

  [JsonPropertyName("frequency_penalty")]
  public double? FrequencyPenalty { get; set; }

  [JsonPropertyName("max_tokens")]
  public int? MaxTokens { get; set; }

  [JsonPropertyName("presence_penalty")]
  public double? PresencePenalty { get; set; }

  [JsonPropertyName("response_format")]
  public DeepSeekResponseFormat? ResponseFormat { get; set; }

  public string[]? Stop { get; set; }

  public bool Stream { get; set; }

  [JsonPropertyName("stream_options")]
  public object? StreamOptions { get; set; }

  public double? Temperature { get; set; }

  [JsonPropertyName("top_p")]
  public double? TopP { get; set; }

  public object? Tools { get; set; }

  [JsonPropertyName("tool_choice")]
  public string? ToolChoice { get; set; }

  public bool? LogProbs { get; set; }

  [JsonPropertyName("top_logprobs")]
  public int? TopLogProbs { get; set; }

  public void ClearMessages()
  {
    Messages.Clear();
  }
}
