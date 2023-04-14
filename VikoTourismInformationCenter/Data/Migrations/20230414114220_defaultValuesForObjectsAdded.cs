using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VikoTourismInformationCenter.Data.Migrations
{
    /// <inheritdoc />
    public partial class defaultValuesForObjectsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Excursions_AspNetUsers_ApplicationUserId",
                table: "Excursions");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_Addresses_AddressId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkHours_Places_PlaceId",
                table: "WorkHours");

            migrationBuilder.AlterColumn<int>(
                name: "PlaceId",
                table: "WorkHours",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Places",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Excursions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Excursions_AspNetUsers_ApplicationUserId",
                table: "Excursions",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Addresses_AddressId",
                table: "Places",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkHours_Places_PlaceId",
                table: "WorkHours",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Excursions_AspNetUsers_ApplicationUserId",
                table: "Excursions");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_Addresses_AddressId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkHours_Places_PlaceId",
                table: "WorkHours");

            migrationBuilder.AlterColumn<int>(
                name: "PlaceId",
                table: "WorkHours",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Places",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Excursions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Excursions_AspNetUsers_ApplicationUserId",
                table: "Excursions",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Addresses_AddressId",
                table: "Places",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkHours_Places_PlaceId",
                table: "WorkHours",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
