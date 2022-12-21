using OpenAI.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI.NET.Interfaces
{
    public interface ICodeCompletion : ICompletion
    {
        Task<CompletionResponse> GetCompletion(CodexEngines engine, CompletionRequest request);
        Task<CompletionResponse> GetCompletionRetainedResults(CodexEngines engine, CompletionRequest request);
    }
}
