using CognitiveServices.Utilities;

namespace RestClient.Models.Enumerations
{
    public class ContentType : Enumeration
    {
        public static ContentType ApplicationJson = new ApplicationJsonType();
        public static ContentType OctetStream = new OctetStream();

        public ContentType(int id, string name) 
            : base(id, name)
        {
        }
    }
}
