using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRent.WebApi.Migrations
{
    public partial class renttableupdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "Rents",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "KSSkW9Woh4v8HYHSAZidDQG/+io=", "r1xsR4Pu0M70uJnbtEW04w==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "Rents");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "AAchj/WYK5CnMoau4JUrjTTqScc=", "3KHc3bYPlCC9QabLVjwBKw==" });
        }
    }
}
