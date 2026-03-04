namespace VehicleWebApi.Domain.Entities {
    public class VehicleType
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        protected VehicleType() { }

        public VehicleType(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("VehicleType name is required.");

            Name = name;
        }
    }
}