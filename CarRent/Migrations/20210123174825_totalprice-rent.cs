using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRent.WebApi.Migrations
{
    public partial class totalpricerent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "Rents",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "g1eT0oHGM8gNVPB3YUB3aljyXts=", "s3arMWunFtVdeS+SfvzZBg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Rents");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "Po+rECdVE5gaSecblq2inj8lfMI=", "9DNLH0+Ufm503F9i4uF4DA==" });
        }
    }
}
