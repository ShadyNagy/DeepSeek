using System.Collections.Generic;
using System.Threading.Tasks;
using DeepSeek.ApiClient.Models;

namespace DeepSeek.ApiClient.Interfaces;
public interface IDeepSeekClient
{
  void ClearMessages();
  List<DeepSeekMessage> GetMessages();
  Task<string> SendMessageAsync(string userMessage, DeepSeekModel model = DeepSeekModel.V3, int temperature = 1);
}
