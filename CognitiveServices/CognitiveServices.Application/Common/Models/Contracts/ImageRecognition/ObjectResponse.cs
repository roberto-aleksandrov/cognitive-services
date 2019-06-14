namespace CognitiveServices.Application.Common.Models.Contracts.ImageRecognition
{
    public class ObjectResponse
    {
        public string Object { get; set; }

        public double Confidence { get; set; }

        public ObjectResponse Parent { get; set; }
    }
}
