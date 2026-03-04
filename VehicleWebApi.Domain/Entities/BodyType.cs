namespace VehicleWebApi.Domain.Entities
{
    public class BodyType
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        protected BodyType() { }

        public BodyType(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("BodyType name is required.");

            Name = name;
        }
    }
}