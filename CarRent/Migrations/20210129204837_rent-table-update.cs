using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRent.WebApi.Migrations
{
    public partial class renttableupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPayed",
                table: "Rents");

            migrationBuilder.AddColumn<bool>(
                name: "IsReviewed",
                table: "Rents",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "AAchj/WYK5CnMoau4JUrjTTqScc=", "3KHc3bYPlCC9QabLVjwBKw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReviewed",
                table: "Rents");

            migrationBuilder.AddColumn<bool>(
                name: "IsPayed",
                table: "Rents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "g1eT0oHGM8gNVPB3YUB3aljyXts=", "s3arMWunFtVdeS+SfvzZBg==" });
        }
    }
}
