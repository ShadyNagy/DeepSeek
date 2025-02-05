using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeepSeek.ApiClient.Models;

namespace DeepSeek.ApiClient.Interfaces;
public interface IDeepSeekClient
{
  Task<string> SendMessageAsync(string userMessage, DeepSeekModel model = DeepSeekModel.V3);
}
