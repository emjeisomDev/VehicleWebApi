using VehicleWebApi.Domain.Enums;

namespace VehicleWebApi.Domain.Entities
{
    public abstract class Vehicle
    {
        public int Id { get; protected set; }

        public string Color { get; protected set; }

        public int ModelVersionId { get; protected set; }
        public ModelVersion ModelVersion { get; protected set; }

        public int VehicleTypeId { get; protected set; }
        public VehicleType VehicleType { get; protected set; }

        protected Vehicle() { }

        protected Vehicle(
            string color,
            int modelVersionId,
            VehicleTypeConstants vehicleType)
        {
            if (string.IsNullOrWhiteSpace(color))
                throw new ArgumentException("Color is required.");

            Color = color;
            ModelVersionId = modelVersionId;
            VehicleTypeId = (int)vehicleType;
        }
    }
}