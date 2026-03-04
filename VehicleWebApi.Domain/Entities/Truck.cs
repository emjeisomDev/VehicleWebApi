using VehicleWebApi.Domain.Enums;

namespace VehicleWebApi.Domain.Entities
{
    public sealed class Truck : Vehicle
    {
        public decimal LoadCapacityInTons { get; private set; }
        public int? AxlesQuantity { get; private set; }

        public int? BodyTypeId { get; private set; }
        public BodyType BodyType { get; private set; }

        protected Truck() { }

        public Truck(
            string color,
            int modelVersionId,
            decimal loadCapacityInTons,
            int? axlesQuantity,
            int? bodyTypeId)
            : base(color, modelVersionId, VehicleTypeConstants.Truck)
        {
            if (loadCapacityInTons <= 0)
                throw new ArgumentException("Load capacity must be greater than zero.");

            LoadCapacityInTons = loadCapacityInTons;
            AxlesQuantity = axlesQuantity;
            BodyTypeId = bodyTypeId;
        }
    }
}