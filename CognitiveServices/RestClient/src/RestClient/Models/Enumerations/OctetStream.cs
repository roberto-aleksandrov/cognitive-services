namespace RestClient.Models.Enumerations
{
    public class OctetStream : ContentType
    {
        private const int _id = 1;
        private const string _name = "application/octet-stream";

        public OctetStream() 
            : base(_id, _name)
        {
        }
    }
}
