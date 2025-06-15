using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HepsiBuraApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DbCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 6, 13, 16, 44, 14, 768, DateTimeKind.Local).AddTicks(8492), "Health" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 6, 13, 16, 44, 14, 768, DateTimeKind.Local).AddTicks(8533), "Grocery, Sports & Industrial" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 6, 13, 16, 44, 14, 768, DateTimeKind.Local).AddTicks(8538), "Automotive" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 13, 16, 44, 14, 769, DateTimeKind.Local).AddTicks(127));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 13, 16, 44, 14, 769, DateTimeKind.Local).AddTicks(129));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 13, 16, 44, 14, 769, DateTimeKind.Local).AddTicks(130));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 13, 16, 44, 14, 769, DateTimeKind.Local).AddTicks(131));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 6, 13, 16, 44, 14, 770, DateTimeKind.Local).AddTicks(3362), "Sit et sed de ipsa.", "Voluptatum biber cesurca deleniti." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 6, 13, 16, 44, 14, 770, DateTimeKind.Local).AddTicks(3397), "Biber veniam öyle quasi sevindi.", "Velit ut." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 6, 13, 16, 44, 14, 770, DateTimeKind.Local).AddTicks(3418), "Ex ex ad sıla modi.", "İpsa." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 6, 13, 16, 44, 14, 772, DateTimeKind.Local).AddTicks(28), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 1.987753898631907m, 404.08m, "Sleek Plastic Soap" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 6, 13, 16, 44, 14, 772, DateTimeKind.Local).AddTicks(78), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 2.986987909526362m, 84.74m, "Awesome Concrete Chicken" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 6, 12, 16, 27, 12, 586, DateTimeKind.Local).AddTicks(6436), "Beauty, Baby & Industrial" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 6, 12, 16, 27, 12, 586, DateTimeKind.Local).AddTicks(6446), "Beauty & Grocery" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 6, 12, 16, 27, 12, 586, DateTimeKind.Local).AddTicks(6451), "Toys" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 16, 27, 12, 586, DateTimeKind.Local).AddTicks(8192));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 16, 27, 12, 586, DateTimeKind.Local).AddTicks(8227));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 16, 27, 12, 586, DateTimeKind.Local).AddTicks(8228));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 6, 12, 16, 27, 12, 586, DateTimeKind.Local).AddTicks(8230));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 6, 12, 16, 27, 12, 588, DateTimeKind.Local).AddTicks(3803), "Anlamsız quasi okuma architecto molestiae.", "Commodi voluptatem quasi için cezbelendi." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 6, 12, 16, 27, 12, 588, DateTimeKind.Local).AddTicks(3842), "Ki sinema eum consequuntur sequi.", "Accusantium biber." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 6, 12, 16, 27, 12, 588, DateTimeKind.Local).AddTicks(3864), "Qui quia duyulmamış veniam quam.", "Voluptatem." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 6, 12, 16, 27, 12, 590, DateTimeKind.Local).AddTicks(1661), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 3.118698177102667m, 646.19m, "Handcrafted Frozen Fish" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 6, 12, 16, 27, 12, 590, DateTimeKind.Local).AddTicks(1684), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 9.168982359201622m, 641.16m, "Refined Fresh Bike" });
        }
    }
}
