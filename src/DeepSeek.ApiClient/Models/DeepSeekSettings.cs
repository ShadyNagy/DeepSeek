using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepSeek.ApiClient.Models;
public class DeepSeekSettings
{
  public string ApiKey { get; }
  public string SystemMessage { get; }
  public string BaseApi { get; }

  public DeepSeekSettings(string apiKey, string? baseApi = null, string systemMessage = "You are a helpful assistant.")
  {
    BaseApi = baseApi ?? "https://api.deepseek.com";
    ApiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
    SystemMessage = systemMessage;
  }
}
