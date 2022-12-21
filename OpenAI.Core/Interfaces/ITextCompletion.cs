using OpenAI.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI.NET.Interfaces
{
    public interface ITextCompletion : ICompletion
    {
        Task<CompletionResponse> GetCompletion(GPTEngines engine, CompletionRequest request);
        Task<CompletionResponse> GetCompletionRetainedResults(GPTEngines engine, CompletionRequest request);
    }
}
