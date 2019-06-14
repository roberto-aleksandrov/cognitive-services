namespace CognitiveServices.Core.Common.Models.Enumerations.VisualFeatures
{
    public class FaceType : VisualFeature
    {
        private const int _id = 1;
        private const string _name = "face";

        public FaceType()
            : base(_id, _name)
        {
        }
    }
}
