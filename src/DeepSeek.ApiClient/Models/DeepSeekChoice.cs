using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DeepSeek.ApiClient.Models;
public class DeepSeekChoice
{
  public int Index { get; set; }
 
  public DeepSeekMessage? Message { get; set; }

  [JsonPropertyName("finish_reason")]
  public string FinishReason { get; set; } = string.Empty;
}
