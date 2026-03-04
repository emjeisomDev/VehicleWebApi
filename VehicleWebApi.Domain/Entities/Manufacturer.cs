namespace VehicleWebApi.Domain.Entities
{
    public class Manufacturer
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public ICollection<Model> Models { get; private set; } = new List<Model>();
        protected Manufacturer() { }

        public Manufacturer(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Manufacturer name is required.");

            Name = name;
        }

    }
}
