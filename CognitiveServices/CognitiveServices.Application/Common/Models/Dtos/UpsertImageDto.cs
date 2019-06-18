using System.Collections.Generic;

namespace CognitiveServices.Application.Common.Dtos
{
    public class UpsertImageDto
    {
        public byte[] Content { get; set; }

        public IEnumerable<int> CategoryIds { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
