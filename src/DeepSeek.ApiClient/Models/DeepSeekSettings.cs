using System;

namespace DeepSeek.ApiClient.Models;
public class DeepSeekSettings
{
  public string SystemMessage { get; }

  public DeepSeekSettings(string systemMessage = "You are a helpful assistant.")
  {   
    SystemMessage = systemMessage;
  }
}
