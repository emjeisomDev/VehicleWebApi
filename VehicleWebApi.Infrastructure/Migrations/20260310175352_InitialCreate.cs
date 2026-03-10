using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VehicleWebApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BodyType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Model_Manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ModelVersion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelVersion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelVersion_Model_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModelVersionId = table.Column<int>(type: "int", nullable: false),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_ModelVersion_ModelVersionId",
                        column: x => x.ModelVersionId,
                        principalTable: "ModelVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleType_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DoorsQuantity = table.Column<int>(type: "int", nullable: false),
                    TrunkLiters = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    HasSunroof = table.Column<bool>(type: "bit", nullable: true),
                    BodyTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Car_BodyType_BodyTypeId",
                        column: x => x.BodyTypeId,
                        principalTable: "BodyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_Vehicle_Id",
                        column: x => x.Id,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Motorcycle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    EngineDisplacement = table.Column<int>(type: "int", nullable: false),
                    HandlebarType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HasElectricStart = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorcycle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motorcycle_Vehicle_Id",
                        column: x => x.Id,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Truck",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    LoadCapacityInTons = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    AxlesQuantity = table.Column<int>(type: "int", nullable: true),
                    BodyTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Truck", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Truck_BodyType_BodyTypeId",
                        column: x => x.BodyTypeId,
                        principalTable: "BodyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Truck_Vehicle_Id",
                        column: x => x.Id,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BodyType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sedan" },
                    { 2, "Hatchback" },
                    { 3, "SUV" },
                    { 4, "Coupé" },
                    { 5, "Convertible" },
                    { 6, "Station Wagon" },
                    { 7, "Minivan" },
                    { 8, "Sports Car" },
                    { 9, "Pickup Truck" },
                    { 10, "Electric Vehicle" },
                    { 11, "Semi-Truck" },
                    { 12, "Dump Truck" },
                    { 13, "Box Truck" },
                    { 14, "Flatbed Truck" },
                    { 15, "Refrigerated Truck" },
                    { 16, "Tanker Truck" },
                    { 17, "Tow Truck" },
                    { 18, "Concrete Mixer Truck" },
                    { 19, "Garbage Truck" },
                    { 20, "Fire Truck" }
                });

            migrationBuilder.InsertData(
                table: "VehicleType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Car" },
                    { 2, "Truck" },
                    { 3, "Motorcycle" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BodyType_Name",
                table: "BodyType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Car_BodyTypeId",
                table: "Car",
                column: "BodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Model_ManufacturerId_Name",
                table: "Model",
                columns: new[] { "ManufacturerId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModelVersion_ModelId_Year",
                table: "ModelVersion",
                columns: new[] { "ModelId", "Year" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Truck_BodyTypeId",
                table: "Truck",
                column: "BodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ModelVersionId",
                table: "Vehicle",
                column: "ModelVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleTypeId",
                table: "Vehicle",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleType_Name",
                table: "VehicleType",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Motorcycle");

            migrationBuilder.DropTable(
                name: "Truck");

            migrationBuilder.DropTable(
                name: "BodyType");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "ModelVersion");

            migrationBuilder.DropTable(
                name: "VehicleType");

            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.DropTable(
                name: "Manufacturer");
        }
    }
}
