using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepSeek.ApiClient.Models;
public class DeepSeekRequestBuilder
{
  private readonly DeepSeekRequest _request = new();

  public DeepSeekRequestBuilder SetModel(DeepSeekModel model)
  {
    _request.Model = model switch
    {
      DeepSeekModel.V3 => "deepseek-chat",
      DeepSeekModel.R1 => "deepseek-reasoner",
      _ => "deepseek-chat"
    };

    return this;
  }

  public DeepSeekRequestBuilder SetStream(bool stream)
  {
    _request.Stream = stream;

    return this;
  }

  public DeepSeekRequestBuilder AddMessage(string role, string content)
  {
    _request.Messages.Add(new DeepSeekMessage(role, content));
    return this;
  }

  public DeepSeekRequestBuilder AddUserMessage(string content)
  {
    _request.Messages.Add(new DeepSeekMessage("user", content));
    return this;
  }

  public DeepSeekRequestBuilder AddSystemMessage(string content)
  {
    _request.Messages.Add(new DeepSeekMessage("system", content));
    return this;
  }

  public DeepSeekRequestBuilder SetMaxTokens(int maxTokens)
  {
    _request.MaxTokens = maxTokens;
    return this;
  }

  public DeepSeekRequestBuilder SetTemperature(double temperature)
  {
    _request.Temperature = temperature;
    return this;
  }

  public DeepSeekRequestBuilder SetTopP(double topP)
  {
    _request.TopP = topP;
    return this;
  }

  public DeepSeekRequestBuilder SetResponseFormat(string type)
  {
    _request.ResponseFormat = new DeepSeekResponseFormat(type);
    return this;
  }

  public DeepSeekRequestBuilder EnableStreaming()
  {
    _request.Stream = true;
    return this;
  }

  public DeepSeekRequest Build() => _request;
}
