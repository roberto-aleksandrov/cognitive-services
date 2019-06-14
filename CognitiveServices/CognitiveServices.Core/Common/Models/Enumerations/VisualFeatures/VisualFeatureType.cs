using CognitiveServices.Utilities;

namespace CognitiveServices.Core.Common.Models.Enumerations.VisualFeatures
{
    public class VisualFeatureType : Enumeration
    {
        public static readonly FaceType Face = new FaceType();
        public static readonly CategoryType Category = new CategoryType();

        public VisualFeatureType(int id, string name)
            : base(id, name)
        {
        }
    }
}
