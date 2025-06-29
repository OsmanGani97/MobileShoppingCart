using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMobileSite.Data.Migrations
{
    /// <inheritdoc />
    public partial class WithoutSoftwareTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hardware_SoftWareMobile");

            migrationBuilder.DropTable(
                name: "Hardware_SoftWare");

            migrationBuilder.AddColumn<string>(
                name: "OperatingSystem",
                table: "Mobile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OperatingSystem",
                table: "Mobile");

            migrationBuilder.CreateTable(
                name: "Hardware_SoftWare",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Architecture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Chipset = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CpuCores = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fabrication = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperatingSystem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OsVersion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserInterface = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hardware_SoftWare", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hardware_SoftWareMobile",
                columns: table => new
                {
                    Hardware_SoftWareId = table.Column<int>(type: "int", nullable: false),
                    MobileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hardware_SoftWareMobile", x => new { x.Hardware_SoftWareId, x.MobileId });
                    table.ForeignKey(
                        name: "FK_Hardware_SoftWareMobile_Hardware_SoftWare_Hardware_SoftWareId",
                        column: x => x.Hardware_SoftWareId,
                        principalTable: "Hardware_SoftWare",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hardware_SoftWareMobile_Mobile_MobileId",
                        column: x => x.MobileId,
                        principalTable: "Mobile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hardware_SoftWareMobile_MobileId",
                table: "Hardware_SoftWareMobile",
                column: "MobileId");
        }
    }
}
