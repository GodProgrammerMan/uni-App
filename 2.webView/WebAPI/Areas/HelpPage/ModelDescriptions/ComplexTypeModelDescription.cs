using System.Collections.ObjectModel;

namespace WebAPI
{
    public class ComplexTypeModelDescription : ModelDescription
    {
        public ComplexTypeModelDescription()
        {
            Properties = new Collection<ParameterDescription>();
        }

        public bool IsAddDescription { get; set; }

        public Collection<ParameterDescription> Properties { get; private set; }
    }
}