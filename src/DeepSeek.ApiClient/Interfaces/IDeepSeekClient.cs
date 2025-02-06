using System.Collections.Generic;
using System.Threading.Tasks;
using DeepSeek.ApiClient.Models;

namespace DeepSeek.ApiClient.Interfaces;
public interface IDeepSeekClient
{
  Task<string> SendMessageAsync(string userMessage, DeepSeekModel model = DeepSeekModel.V3);
  Task<string> SendMessageAsync(DeepSeekRequest request);
}
