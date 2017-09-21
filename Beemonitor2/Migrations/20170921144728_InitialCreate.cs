using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Beemonitor2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apiaries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apiaries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SensorTypes",
                columns: table => new
                {
                    SensorTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorTypes", x => x.SensorTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Beehives",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApiaryID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beehives", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Beehives_Apiaries_ApiaryID",
                        column: x => x.ApiaryID,
                        principalTable: "Apiaries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sensors",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SensorTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Sensors_SensorTypes_SensorTypeId",
                        column: x => x.SensorTypeId,
                        principalTable: "SensorTypes",
                        principalColumn: "SensorTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BeehiveSensors",
                columns: table => new
                {
                    BeehiveId = table.Column<int>(type: "int", nullable: false),
                    SensorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeehiveSensors", x => new { x.BeehiveId, x.SensorName });
                    table.ForeignKey(
                        name: "FK_BeehiveSensors_Beehives_BeehiveId",
                        column: x => x.BeehiveId,
                        principalTable: "Beehives",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeehiveSensors_Sensors_SensorName",
                        column: x => x.SensorName,
                        principalTable: "Sensors",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Observations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ObsDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ObsValue = table.Column<float>(type: "real", nullable: false),
                    SensorName = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Observations_Sensors_SensorName",
                        column: x => x.SensorName,
                        principalTable: "Sensors",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beehives_ApiaryID",
                table: "Beehives",
                column: "ApiaryID");

            migrationBuilder.CreateIndex(
                name: "IX_BeehiveSensors_SensorName",
                table: "BeehiveSensors",
                column: "SensorName");

            migrationBuilder.CreateIndex(
                name: "IX_Observations_SensorName",
                table: "Observations",
                column: "SensorName");

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_SensorTypeId",
                table: "Sensors",
                column: "SensorTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeehiveSensors");

            migrationBuilder.DropTable(
                name: "Observations");

            migrationBuilder.DropTable(
                name: "Beehives");

            migrationBuilder.DropTable(
                name: "Sensors");

            migrationBuilder.DropTable(
                name: "Apiaries");

            migrationBuilder.DropTable(
                name: "SensorTypes");
        }
    }
}
