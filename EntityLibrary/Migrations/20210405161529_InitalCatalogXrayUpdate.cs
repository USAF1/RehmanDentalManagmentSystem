using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityLibrary.Migrations
{
    public partial class InitalCatalogXrayUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Xray",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Xray", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientXray",
                columns: table => new
                {
                    PatientsId = table.Column<int>(type: "int", nullable: false),
                    XRaysId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientXray", x => new { x.PatientsId, x.XRaysId });
                    table.ForeignKey(
                        name: "FK_PatientXray_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientXray_Xray_XRaysId",
                        column: x => x.XRaysId,
                        principalTable: "Xray",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientXray_XRaysId",
                table: "PatientXray",
                column: "XRaysId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientXray");

            migrationBuilder.DropTable(
                name: "Xray");
        }
    }
}
