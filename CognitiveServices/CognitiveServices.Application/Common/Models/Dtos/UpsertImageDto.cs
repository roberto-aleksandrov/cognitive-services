using System.Collections.Generic;

namespace CognitiveServices.Application.Common.Dtos
{
    public class UpsertImageDto
    {
        public byte[] Content { get; set; }

        public IEnumerable<int> CategoryIds { get; set; }
    }
}
