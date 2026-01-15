using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketHive.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Artist", "Capacity", "CreatedDate", "Date", "Description", "LastModifiedDate", "Name", "Price" },
                values: new object[] { new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "The Queries", 500, new DateTime(2026, 1, 15, 14, 15, 38, 951, DateTimeKind.Utc).AddTicks(6222), new DateTime(2026, 2, 15, 14, 15, 38, 951, DateTimeKind.Utc).AddTicks(6260), "A night of high-performance music.", null, "PostgreSQL Rock Night", 45.00m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"));
        }
    }
}
