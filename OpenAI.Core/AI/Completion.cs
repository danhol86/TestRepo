using Newtonsoft.Json;
using OpenAI.NET.Interfaces;
using OpenAI.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI.NET.AI
{
    public class Completion : ICodeCompletion, ITextCompletion, ICompletion
    {
        private List<string> priorResponses = new List<string>();
        public async Task<CompletionResponse> GetCompletion(GPTEngines engine, CompletionRequest request)
        {
            return await GetResponse(engine, request);
        }

        public async Task<CompletionResponse> GetCompletion(CodexEngines engine, CompletionRequest request)
        {
            
            return await GetResponse(engine, request);
        }

        public async Task<CompletionResponse> GetCompletion(string engine, CompletionRequest request)
        {
            return await GetResponse(engine, request);
        }

        public async Task<CompletionResponse> GetCompletionRetainedResults(GPTEngines engine, CompletionRequest request)
        {            
            if (priorResponses.Any())
            {
                request.prompt = string.Join(Environment.NewLine, priorResponses) + Environment.NewLine + request.prompt;
            }
            
            var returnValue = await GetResponse(engine, request);
            priorResponses.Add($"{request.prompt} {Environment.NewLine} {returnValue.choices.FirstOrDefault().text} {Environment.NewLine}{Environment.NewLine}");
            return returnValue;
        }

        public async Task<CompletionResponse> GetCompletionRetainedResults(CodexEngines engine, CompletionRequest request)
        {
            var returnValue = await GetResponse(engine, request);
            priorResponses.Add($"{request.prompt} {Environment.NewLine} {returnValue.choices.FirstOrDefault().text} {Environment.NewLine}{Environment.NewLine}");
            return returnValue;
        }

        public async Task<CompletionResponse> GetCompletionRetainedResults(string engine, CompletionRequest request)
        {
            var returnValue = await GetResponse(engine, request);
            priorResponses.Add($"{request.prompt} {Environment.NewLine} {returnValue.choices.FirstOrDefault().text} {Environment.NewLine}{Environment.NewLine}");
            return returnValue;
        }

        private async Task<CompletionResponse> GetResponse<T>(T engine, CompletionRequest request)
        {
            string engineStr = string.Empty;

            if (engine.GetType() == typeof(GPTEngines))
            {
                var engineTypeVar = (GPTEngines)Convert.ChangeType(engine, typeof(GPTEngines));
                engineStr = $"text-{engineTypeVar.ToString().ToLower()}-{(engineTypeVar == GPTEngines.DAVINCI ? "003" : "001")}";
            }

            if (engine.GetType() == typeof(CodexEngines))
            {
                var engineTypeVar = (CodexEngines)Convert.ChangeType(engine, typeof(CodexEngines));
                engineStr = $"code-{engineTypeVar.ToString()}-{(engineTypeVar == CodexEngines.DAVINCI ? "002" : "001")}";
            }

            if (engine.GetType() == typeof(string))
            {
                engineStr = engine.ToString();
            }
            request.model = engineStr;
             CompletionResponse returnValue = null;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {OpenAPI.ApiKey}");

                await client.PostAsync("https://api.openai.com/v1/completions", new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json")
                ).ContinueWith(response =>
                {
                    if (!response.Result.IsSuccessStatusCode)
                        throw new Exception(response.Result.ReasonPhrase);

                    returnValue = JsonConvert.DeserializeObject<CompletionResponse>(response.Result.Content.ReadAsStringAsync().Result);
                });

                return returnValue;
            }
        }

    }
}
