using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DeepSeek.ApiClient.Models;
public class DeepSeekResponse
{
  [JsonPropertyName("id")]
  public string Id { get; set; } = string.Empty;

  [JsonPropertyName("object")]
  public string Object { get; set; } = string.Empty;

  [JsonPropertyName("created")]
  public long Created { get; set; }

  [JsonPropertyName("model")]
  public string Model { get; set; } = string.Empty;

  [JsonPropertyName("choices")]
  public List<DeepSeekChoice>? Choices { get; set; }

  [JsonPropertyName("usage")]
  public DeepSeekUsage Usage { get; set; }
}
