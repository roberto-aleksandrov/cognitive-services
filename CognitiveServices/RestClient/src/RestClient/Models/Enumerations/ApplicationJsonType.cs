namespace RestClient.Models.Enumerations
{
    public class ApplicationJsonType : ContentType
    {
        private const int _id = 1;
        private const string _name = "application/json";
        
        public ApplicationJsonType() 
            : base(_id, _name)
        {
        }
    }
}
