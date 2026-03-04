using VehicleWebApi.Domain.Enums;

namespace VehicleWebApi.Domain.Entities
{
    public sealed class Car : Vehicle
    {
        public int DoorsQuantity { get; private set; }
        public decimal? TrunkLiters { get; private set; }
        public bool? HasSunroof { get; private set; }

        public int? BodyTypeId { get; private set; }
        public BodyType BodyType { get; private set; }

        protected Car() { }

        public Car(
            string color,
            int modelVersionId,
            int doorsQuantity,
            decimal? trunkLiters,
            bool? hasSunroof,
            int? bodyTypeId)
            : base(color, modelVersionId, VehicleTypeConstants.Car)
        {
            if (doorsQuantity <= 0)
                throw new ArgumentException("DoorsQuantity must be greater than zero.");

            DoorsQuantity = doorsQuantity;
            TrunkLiters = trunkLiters;
            HasSunroof = hasSunroof;
            BodyTypeId = bodyTypeId;
        }
    }
}