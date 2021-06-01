using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityLibrary.Migrations
{
    public partial class InitalCatalogXrayUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientXray_Xray_XRaysId",
                table: "PatientXray");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Xray",
                table: "Xray");

            migrationBuilder.RenameTable(
                name: "Xray",
                newName: "XRays");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "XRays",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_XRays",
                table: "XRays",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientXray_XRays_XRaysId",
                table: "PatientXray",
                column: "XRaysId",
                principalTable: "XRays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientXray_XRays_XRaysId",
                table: "PatientXray");

            migrationBuilder.DropPrimaryKey(
                name: "PK_XRays",
                table: "XRays");

            migrationBuilder.RenameTable(
                name: "XRays",
                newName: "Xray");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Xray",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Xray",
                table: "Xray",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientXray_Xray_XRaysId",
                table: "PatientXray",
                column: "XRaysId",
                principalTable: "Xray",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
