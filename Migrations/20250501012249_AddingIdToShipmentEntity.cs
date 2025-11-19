using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C_Sharp.Migrations
{
    /// <inheritdoc />
    public partial class AddingIdToShipmentEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsShipped",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ShipmentId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "TotalPrice",
                table: "Orders",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "Shipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<float>(type: "real", nullable: false),
                    ShippingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipment", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShipmentId",
                table: "Orders",
                column: "ShipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Shipment_ShipmentId",
                table: "Orders",
                column: "ShipmentId",
                principalTable: "Shipment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Shipment_ShipmentId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Shipment");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShipmentId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsShipped",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShipmentId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Orders");
        }
    }
}
