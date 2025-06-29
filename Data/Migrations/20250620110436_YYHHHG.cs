using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMobileSite.Data.Migrations
{
    /// <inheritdoc />
    public partial class YYHHHG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mobile_Hardware_SoftWare_Hardware_SoftWareId",
                table: "Mobile");

            migrationBuilder.DropIndex(
                name: "IX_Mobile_Hardware_SoftWareId",
                table: "Mobile");

            migrationBuilder.DropColumn(
                name: "Hardware_SoftWareId",
                table: "Mobile");

            migrationBuilder.RenameColumn(
                name: "DisplayType",
                table: "Mobile",
                newName: "Display");

            migrationBuilder.RenameColumn(
                name: "BatteryType",
                table: "Mobile",
                newName: "Battery");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hardware_SoftWareMobile");

            migrationBuilder.RenameColumn(
                name: "Display",
                table: "Mobile",
                newName: "DisplayType");

            migrationBuilder.RenameColumn(
                name: "Battery",
                table: "Mobile",
                newName: "BatteryType");

            migrationBuilder.AddColumn<int>(
                name: "Hardware_SoftWareId",
                table: "Mobile",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Mobile_Hardware_SoftWareId",
                table: "Mobile",
                column: "Hardware_SoftWareId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mobile_Hardware_SoftWare_Hardware_SoftWareId",
                table: "Mobile",
                column: "Hardware_SoftWareId",
                principalTable: "Hardware_SoftWare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
