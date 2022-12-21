using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI.NET.Models
{

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CompletionRequest
    {
        public CompletionRequest(string prompt)
        {
            this.prompt = prompt;
        }

        public string prompt { get; set; }
        public string suffix { get; set; }
        public int max_tokens { get; set; } = 1000;
        public decimal? temprature { get; set; }
        public decimal? top_p { get; set; }
        public int? n { get; set; }
        public bool? stream { get; set; }
        public int? logprobs { get; set; }
        public bool? echo { get; set; }
        public string[] stop { get; set; }
        public decimal? presence_penalty { get; set; }
        public decimal? frequency_penalty { get; set; }
        public int? best_of { get; set; }
        public LogitBias logit_bias { get; set; }
        public string model { get; set; }
    }

    public class LogitBias
    {
        public string tokenID { get; set; }
        public int value { get; set; }
    }

    public enum GPTEngines
    {
        DAVINCI,
        CURIE,
        BABBAGE,
    }

    public enum CodexEngines
    {
        DAVINCI,
        CUSHMAN,
    }

    public enum ContentFilterEngine
    {
        ALPHA,
    }
}

