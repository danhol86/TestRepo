using OpenAI.NET.AI;
using OpenAI.NET.Interfaces;


namespace OpenAI.NET
{
    public class OpenAPI
    {
        public static string ApiKey { get; private set; }
        public ICodeCompletion codeCompletion { get; set; }
        public ITextCompletion textCompletion { get; set; }
        public IImageGeneration imageGeneration { get; set; }

        public OpenAPI(string apiKey)
        {
            var tem = "sddsf";
            ApiKey = apiKey;

            var completionInstance = new Completion();
            codeCompletion = completionInstance;
            textCompletion = completionInstance;

            imageGeneration = new ImageGeneration();
        }
    }
}
