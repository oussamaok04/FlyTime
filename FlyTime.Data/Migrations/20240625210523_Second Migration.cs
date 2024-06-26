using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlyTime.Data.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Aeroports_FromDestinationId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Aeroports_ToDestinationId",
                table: "Activities");

            migrationBuilder.AlterColumn<int>(
                name: "ToDestinationId",
                table: "Activities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FromDestinationId",
                table: "Activities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Aeroports_FromDestinationId",
                table: "Activities",
                column: "FromDestinationId",
                principalTable: "Aeroports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Aeroports_ToDestinationId",
                table: "Activities",
                column: "ToDestinationId",
                principalTable: "Aeroports",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Aeroports_FromDestinationId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Aeroports_ToDestinationId",
                table: "Activities");

            migrationBuilder.AlterColumn<int>(
                name: "ToDestinationId",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FromDestinationId",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Aeroports_FromDestinationId",
                table: "Activities",
                column: "FromDestinationId",
                principalTable: "Aeroports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Aeroports_ToDestinationId",
                table: "Activities",
                column: "ToDestinationId",
                principalTable: "Aeroports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
