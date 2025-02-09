using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NzWalkApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForRegion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("08420fab-39c1-4af2-a7d3-566f22d0937c"), "Medium" },
                    { new Guid("b9565e95-ce9a-4d0e-9fc3-679f3d37b70b"), "Easy" },
                    { new Guid("e4426939-7f46-49d7-a867-f98f34431475"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageURL" },
                values: new object[,]
                {
                    { new Guid("24f6e360-cad2-4434-8243-efc362f40bf6"), "NSN", "Nelson", "https://fastly.picsum.photos/id/17/2500/1667.jpg?hmac=HD-JrnNUZjFiP2UZQvWcKrgLoC_pc_ouUSWv8kHsJJY" },
                    { new Guid("5ff6a69c-e3c5-4b68-8d0e-b7606c8fb06c"), "WGN", "Wellington", "https://fastly.picsum.photos/id/14/2500/1667.jpg?hmac=ssQyTcZRRumHXVbQAVlXTx-MGBxm6NHWD3SryQ48G-o" },
                    { new Guid("760b8e00-296a-4377-b7e2-2994636c744d"), "AKL", "Auckland", "https://fastly.picsum.photos/id/11/2500/1667.jpg?hmac=xxjFJtAPgshYkysU_aqx2sZir-kIOjNR9vx0te7GycQ" },
                    { new Guid("edb31812-6be2-48c8-82f6-bd824433ea31"), "NSN", "Nelson", "https://fastly.picsum.photos/id/15/2500/1667.jpg?hmac=Lv03D1Y3AsZ9L2tMMC1KQZekBVaQSDc1waqJ54IHvo4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("08420fab-39c1-4af2-a7d3-566f22d0937c"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("b9565e95-ce9a-4d0e-9fc3-679f3d37b70b"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("e4426939-7f46-49d7-a867-f98f34431475"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("24f6e360-cad2-4434-8243-efc362f40bf6"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5ff6a69c-e3c5-4b68-8d0e-b7606c8fb06c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("760b8e00-296a-4377-b7e2-2994636c744d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("edb31812-6be2-48c8-82f6-bd824433ea31"));
        }
    }
}
