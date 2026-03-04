namespace VehicleWebApi.Domain.Entities
{
    public class Model
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public int ManufacturerId { get; private set; }
        public Manufacturer Manufacturer { get; private set; }

        public ICollection<ModelVersion> Versions { get; private set; } = new List<ModelVersion>();

        protected Model() { }

        public Model(string name, int manufacturerId)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Model name is required.");

            Name = name;
            ManufacturerId = manufacturerId;
        }
    }
}