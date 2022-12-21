using OpenAI.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI.NET.Interfaces
{
    public interface ICompletion
    {
        Task<CompletionResponse> GetCompletion(string engine, CompletionRequest request);
        Task<CompletionResponse> GetCompletionRetainedResults(string engine, CompletionRequest request);
    }
}
