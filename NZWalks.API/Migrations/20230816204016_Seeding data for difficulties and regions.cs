using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class Seedingdatafordifficultiesandregions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("7d79081a-22f5-4bb9-8a18-b9f3e730ae2e"), "Hard" },
                    { new Guid("a4fc373a-887a-461f-988d-e8fa0a32d126"), "Easy" },
                    { new Guid("f3411f29-5cf1-4c85-a627-773052ea3aa5"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("17cc1a14-3a5b-40c5-aac0-504d54d81493"), "BOP", "Bay of Plenty", "image.com" },
                    { new Guid("337fbaa5-e350-4afe-bf96-5167fc5f6a3c"), "NSN", "Nelson", "image.com" },
                    { new Guid("47cdee8f-0641-41eb-ab8a-e4ae65e676f1"), "AKL", "Auckland", "image.com" },
                    { new Guid("7b3476cb-bc86-43a7-abf5-a908709b2f3b"), "NTL", "Northland", "image.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("7d79081a-22f5-4bb9-8a18-b9f3e730ae2e"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("a4fc373a-887a-461f-988d-e8fa0a32d126"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("f3411f29-5cf1-4c85-a627-773052ea3aa5"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("17cc1a14-3a5b-40c5-aac0-504d54d81493"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("337fbaa5-e350-4afe-bf96-5167fc5f6a3c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("47cdee8f-0641-41eb-ab8a-e4ae65e676f1"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("7b3476cb-bc86-43a7-abf5-a908709b2f3b"));
        }
    }
}
