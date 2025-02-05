using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DeepSeek.ApiClient.Models;
public class DeepSeekResponse
{
  public string Id { get; set; } = string.Empty; 
  public string Object { get; set; } = string.Empty;
  public long Created { get; set; }
  public string Model { get; set; } = string.Empty;
  public List<DeepSeekChoice>? Choices { get; set; }
  public DeepSeekUsage? Usage { get; set; }
}
