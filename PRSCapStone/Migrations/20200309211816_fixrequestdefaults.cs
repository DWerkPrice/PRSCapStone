using Microsoft.EntityFrameworkCore.Migrations;

namespace PRSCapStone.Migrations
{
    public partial class fixrequestdefaults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Requests",
                maxLength: 10,
                nullable: false,
                defaultValue: "New",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValue: "'New'");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryMode",
                table: "Requests",
                maxLength: 20,
                nullable: false,
                defaultValue: "Pickup",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldDefaultValue: "'Pickup'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Requests",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "'New'",
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldDefaultValue: "New");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryMode",
                table: "Requests",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "'Pickup'",
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldDefaultValue: "Pickup");
        }
    }
}
