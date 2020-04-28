using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SensorFusion.Shared.Data.Migrations
{
    public partial class AddedSensorValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SensorValues",
                columns: table => new
                {
                    SensorId = table.Column<int>(nullable: false),
                    TimeSent = table.Column<DateTime>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorValues", x => new { x.SensorId, x.TimeSent });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SensorValues");
        }
    }
}
