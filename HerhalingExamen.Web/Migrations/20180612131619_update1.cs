using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HerhalingExamen.Web.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductInfo_ProductId",
                table: "ProductInfo");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Image", "Name", "UserId" },
                values: new object[] { new Guid("15600c2e-112d-47d9-aaf8-c05bf0990391"), "Foto van het eerste product", "Eerste Product", null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Image", "Name", "UserId" },
                values: new object[] { new Guid("93f9c35a-3cf4-45c4-a3f8-66a44150010a"), "Foto van het tweede product", "Tweede Product", null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Image", "Name", "UserId" },
                values: new object[] { new Guid("426cfdad-2ebf-48e8-9e16-134ab54b465e"), "Foto van het derde product", "Derde Product", null });

            migrationBuilder.CreateIndex(
                name: "IX_ProductInfo_ProductId",
                table: "ProductInfo",
                column: "ProductId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductInfo_ProductId",
                table: "ProductInfo");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("15600c2e-112d-47d9-aaf8-c05bf0990391"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("426cfdad-2ebf-48e8-9e16-134ab54b465e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("93f9c35a-3cf4-45c4-a3f8-66a44150010a"));

            migrationBuilder.CreateIndex(
                name: "IX_ProductInfo_ProductId",
                table: "ProductInfo",
                column: "ProductId");
        }
    }
}
