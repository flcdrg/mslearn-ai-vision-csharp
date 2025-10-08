#:package Azure.AI.Vision.ImageAnalysis@1.0.0

// Import namespaces
using Azure;
using Azure.AI.Vision.ImageAnalysis;

var ai_endpoint = Environment.GetEnvironmentVariable("AI_SERVICE_ENDPOINT") ?? throw new InvalidOperationException("Please set the AI_SERVICE_ENDPOINT environment variable.");
var ai_key = Environment.GetEnvironmentVariable("AI_SERVICE_KEY") ?? throw new InvalidOperationException("Please set the AI_SERVICE_KEY environment variable.");

// Authenticate Azure AI Vision client
var client = new ImageAnalysisClient(new Uri(ai_endpoint), new AzureKeyCredential(ai_key));

// # Analyze image
var result = (await client.AnalyzeAsync(new Uri("https://raw.githubusercontent.com/MicrosoftLearning/mslearn-ai-vision/06cf25b6c104c7a45c6b0250702f28ddefc37538/Labfiles/analyze-images/python/image-analysis/images/street.jpg"),
VisualFeatures.Caption | VisualFeatures.DenseCaptions | VisualFeatures.Tags | VisualFeatures.Objects | VisualFeatures.People
)).Value;

// # Get image captions
if (result.Caption is not null) {
    Console.WriteLine("Caption:");
    Console.WriteLine($" Caption: {result.Caption.Text}, Confidence: {result.Caption.Confidence * 100:F2}%");
}

if (result.DenseCaptions is not null) {
    Console.WriteLine("Dense Captions:");
    foreach (var caption in result.DenseCaptions.Values)
    {
        Console.WriteLine($" Caption: {caption.Text}, Confidence: {caption.Confidence * 100:F2}%");
    }
}

// # Get image tags
if (result.Tags is not null) {
    Console.WriteLine("Tags:");
    foreach (var tag in result.Tags.Values)
    {
        Console.WriteLine($" Tag: {tag.Name}, Confidence: {tag.Confidence * 100:F2}%");
    }
}

// # Get objects in the image
if (result.Objects is not null) {
    Console.WriteLine("Objects in the image:");
    foreach (var obj in result.Objects.Values)
    {
        Console.WriteLine($" Object: {obj.Tags[0].Name}, Confidence: {obj.Tags[0].Confidence * 100:F2}%");
    }
}

// # Get people in the image
if (result.People is not null)
{
    Console.WriteLine("People in the image:");
    foreach (var person in result.People.Values)
    {
        if (person.Confidence > 0.2)
        {
            Console.WriteLine($" {person.BoundingBox} Confidence: {person.Confidence * 100:F2}%");
        }
    }
}
