using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HerhalingExamen.Web.Migrations
{
    public partial class AdminPropForUsersAndSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "ProductInfo",
                columns: new[] { "Id", "Description", "ProductId" },
                values: new object[,]
                {
                    { new Guid("e2186f7c-4944-4dcb-a373-589d41fb9dc4"), "de description van het eerste product", new Guid("15600c2e-112d-47d9-aaf8-c05bf0990391") },
                    { new Guid("c068d22a-6b23-426b-817a-e1b1c1465936"), "de description van het tweede product", new Guid("93f9c35a-3cf4-45c4-a3f8-66a44150010a") },
                    { new Guid("e91ae6fa-fe00-4fcd-a744-9d51e95da77d"), "de description van het derde product", new Guid("426cfdad-2ebf-48e8-9e16-134ab54b465e") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsAdmin", "Name", "Password" },
                values: new object[,]
                {
                    { new Guid("2608f8ad-79e6-419d-a98c-fab17875a7ca"), false, "Brian", "password" },
                    { new Guid("f252f827-8284-4a4c-8343-9caf41e39916"), true, "Administrator", "password" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductInfo",
                keyColumn: "Id",
                keyValue: new Guid("c068d22a-6b23-426b-817a-e1b1c1465936"));

            migrationBuilder.DeleteData(
                table: "ProductInfo",
                keyColumn: "Id",
                keyValue: new Guid("e2186f7c-4944-4dcb-a373-589d41fb9dc4"));

            migrationBuilder.DeleteData(
                table: "ProductInfo",
                keyColumn: "Id",
                keyValue: new Guid("e91ae6fa-fe00-4fcd-a744-9d51e95da77d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2608f8ad-79e6-419d-a98c-fab17875a7ca"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f252f827-8284-4a4c-8343-9caf41e39916"));

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Users");
        }
    }
}
