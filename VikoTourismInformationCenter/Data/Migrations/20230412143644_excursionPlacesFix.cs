using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VikoTourismInformationCenter.Data.Migrations
{
    /// <inheritdoc />
    public partial class excursionPlacesFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "ExcursionsPlaces",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ExcursionsPlaces_PlaceId",
                table: "ExcursionsPlaces",
                column: "PlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExcursionsPlaces_Places_PlaceId",
                table: "ExcursionsPlaces",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExcursionsPlaces_Places_PlaceId",
                table: "ExcursionsPlaces");

            migrationBuilder.DropIndex(
                name: "IX_ExcursionsPlaces_PlaceId",
                table: "ExcursionsPlaces");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "ExcursionsPlaces");
        }
    }
}
