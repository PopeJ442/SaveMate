using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaveMate.Migrations
{
    /// <inheritdoc />
    public partial class CustomTyperemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AccountCustomTypes_CustomTypeId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_CustomTypeId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CustomTypeId",
                table: "Accounts");

            migrationBuilder.AlterColumn<int>(
                name: "PredefinedType",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PredefinedType",
                table: "Accounts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CustomTypeId",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CustomTypeId",
                table: "Accounts",
                column: "CustomTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AccountCustomTypes_CustomTypeId",
                table: "Accounts",
                column: "CustomTypeId",
                principalTable: "AccountCustomTypes",
                principalColumn: "Id");
        }
    }
}
