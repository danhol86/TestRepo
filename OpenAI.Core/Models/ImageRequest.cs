using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI.NET.Models
{
    /// <summary>
    /// https://beta.openai.com/docs/api-reference/images/create
    /// </summary>
    public class ImageRequest
    {
        public string prompt { get; set; }
        public int n { get; set; }
        public ImageSize size { get; set; }
        public ResponseFormat response_format { get; set; }
        public string user { get; set; }
    }

    public enum ResponseFormat
    {
        url,
        b64_json
    }

    public enum ImageSize
    {
        _256x256,
        _512x512,
        _1024x1024
    }
}
