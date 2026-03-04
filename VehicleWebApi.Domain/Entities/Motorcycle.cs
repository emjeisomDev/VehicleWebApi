using VehicleWebApi.Domain.Enums;

namespace VehicleWebApi.Domain.Entities
{
    public sealed class Motorcycle : Vehicle
    {
        public int EngineDisplacement { get; private set; }

        public HandlebarType HandlebarType { get; private set; }

        public bool? HasElectricStart { get; private set; }

        protected Motorcycle() { }

        public Motorcycle(
            string color,
            int modelVersionId,
            int engineDisplacement,
            HandlebarType handlebarType,
            bool? hasElectricStart)
            : base(color, modelVersionId, VehicleTypeConstants.Motorcycle)
        {
            if (engineDisplacement <= 0)
                throw new ArgumentException("Engine displacement must be greater than zero.");

            EngineDisplacement = engineDisplacement;
            HandlebarType = handlebarType;
            HasElectricStart = hasElectricStart;
        }
    }
}