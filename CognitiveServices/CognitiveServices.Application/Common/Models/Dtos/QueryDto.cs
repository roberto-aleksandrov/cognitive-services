namespace CognitiveServices.Application.Common.Models.Dtos
{
    public class QueryDto
    {
        public string Include { get; set; } = "";

        public int? Take { get; set; }

        public int? Skip { get; set; }

        public string Where { get; set; }

    }
}
