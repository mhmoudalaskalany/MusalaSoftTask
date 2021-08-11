using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendCore.Data.Migrations
{
    public partial class MakeSerialNumberUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 11, 4, 31, 20, 165, DateTimeKind.Local).AddTicks(7785), new DateTime(2021, 8, 11, 4, 31, 20, 166, DateTimeKind.Local).AddTicks(5606) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ModifiedDate", "Password" },
                values: new object[] { new DateTime(2021, 8, 11, 4, 31, 20, 167, DateTimeKind.Local).AddTicks(6544), new DateTime(2021, 8, 11, 4, 31, 20, 167, DateTimeKind.Local).AddTicks(6550), "ABRoMV4JpikiLXvpZsSuuqMlVdPTlRaLI755UdLIv4p495h1maraqxvfM4q8krMkJA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Gateways_SerialNumber",
                table: "Gateways",
                column: "SerialNumber",
                unique: true,
                filter: "[SerialNumber] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Gateways_SerialNumber",
                table: "Gateways");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 8, 11, 2, 50, 4, 789, DateTimeKind.Local).AddTicks(1110), new DateTime(2021, 8, 11, 2, 50, 4, 789, DateTimeKind.Local).AddTicks(8552) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "ModifiedDate", "Password" },
                values: new object[] { new DateTime(2021, 8, 11, 2, 50, 4, 790, DateTimeKind.Local).AddTicks(9808), new DateTime(2021, 8, 11, 2, 50, 4, 790, DateTimeKind.Local).AddTicks(9816), "AF8jijmTYZ58vnWmYltREsssQ4HwlD0FD7TrUzhzNcmK4I5nHVguzmDeEpPJXzIuYQ==" });
        }
    }
}
