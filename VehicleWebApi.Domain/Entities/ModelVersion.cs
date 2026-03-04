namespace VehicleWebApi.Domain.Entities
{
    public class ModelVersion
    {
        public int Id { get; private set; }

        public int Year { get; private set; }

        public int ModelId { get; private set; }
        public Model Model { get; private set; }

        public ICollection<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();

        protected ModelVersion() { }

        public ModelVersion(int year, int modelId)
        {
            if (year < 1886 || year > DateTime.UtcNow.Year)
                throw new ArgumentException("Invalid vehicle year.");

            Year = year;
            ModelId = modelId;
        }
    }
}