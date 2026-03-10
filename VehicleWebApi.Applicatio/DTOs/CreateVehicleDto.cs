namespace VehicleWebApi.Application.DTOs
{
    public record CreateVehicleDto
    {
        public string Color { get; init; }
        public int ModelVersionId { get; init; }

        public CreateVehicleDto(string color, int modelVersionId)
        {
            Color = color;
            ModelVersionId = modelVersionId;
        }
    }
}
