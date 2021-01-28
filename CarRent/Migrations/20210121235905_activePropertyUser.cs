using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRent.WebApi.Migrations
{
    public partial class activePropertyUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "Po+rECdVE5gaSecblq2inj8lfMI=", "9DNLH0+Ufm503F9i4uF4DA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "hQrNicdLtLUbF01h9MFOjkElzfU=", "vMgT/M2T9o2DokqgzmKMaw==" });
        }
    }
}
