using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpenseTracker.Migrations
{
    public partial class inti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Expense",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ExpenseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Expense_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expense_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ApplicationUser",
                columns: new[] { "UserId", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "123", "pulak" },
                    { 2, "123", "aninda" },
                    { 3, "123", "Mostafa" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "House Rent" },
                    { 2, "Water Bill" },
                    { 3, "Electric Bill" },
                    { 4, "Groceries" },
                    { 5, "Uber" },
                    { 6, "Medications" }
                });

            migrationBuilder.InsertData(
                table: "Expense",
                columns: new[] { "ItemId", "Amount", "CategoryId", "ExpenseDate", "UserId" },
                values: new object[,]
                {
                    { 1, 10000, 1, new DateTime(2021, 12, 17, 7, 50, 59, 736, DateTimeKind.Local).AddTicks(8530), 1 },
                    { 6, 3000, 6, new DateTime(2021, 12, 17, 7, 50, 59, 737, DateTimeKind.Local).AddTicks(26), 1 },
                    { 17, 2000, 5, new DateTime(2021, 12, 17, 7, 50, 59, 737, DateTimeKind.Local).AddTicks(54), 3 },
                    { 11, 2000, 5, new DateTime(2021, 12, 17, 7, 50, 59, 737, DateTimeKind.Local).AddTicks(39), 2 },
                    { 5, 2000, 5, new DateTime(2021, 12, 17, 7, 50, 59, 737, DateTimeKind.Local).AddTicks(24), 1 },
                    { 16, 5000, 4, new DateTime(2021, 12, 17, 7, 50, 59, 737, DateTimeKind.Local).AddTicks(52), 3 },
                    { 10, 5000, 4, new DateTime(2021, 12, 17, 7, 50, 59, 737, DateTimeKind.Local).AddTicks(36), 2 },
                    { 4, 5000, 4, new DateTime(2021, 12, 17, 7, 50, 59, 737, DateTimeKind.Local).AddTicks(21), 1 },
                    { 15, 1000, 3, new DateTime(2021, 12, 17, 7, 50, 59, 737, DateTimeKind.Local).AddTicks(49), 3 },
                    { 9, 1000, 3, new DateTime(2021, 12, 17, 7, 50, 59, 737, DateTimeKind.Local).AddTicks(34), 2 },
                    { 3, 1000, 3, new DateTime(2021, 12, 17, 7, 50, 59, 737, DateTimeKind.Local).AddTicks(18), 1 },
                    { 14, 600, 2, new DateTime(2021, 12, 17, 7, 50, 59, 737, DateTimeKind.Local).AddTicks(47), 3 },
                    { 8, 600, 2, new DateTime(2021, 12, 17, 7, 50, 59, 737, DateTimeKind.Local).AddTicks(31), 2 },
                    { 2, 600, 2, new DateTime(2021, 12, 17, 7, 50, 59, 737, DateTimeKind.Local).AddTicks(15), 1 },
                    { 13, 3000, 1, new DateTime(2021, 12, 17, 7, 50, 59, 737, DateTimeKind.Local).AddTicks(44), 3 },
                    { 7, 8000, 1, new DateTime(2021, 12, 17, 7, 50, 59, 737, DateTimeKind.Local).AddTicks(29), 2 },
                    { 12, 3000, 6, new DateTime(2021, 12, 17, 7, 50, 59, 737, DateTimeKind.Local).AddTicks(42), 2 },
                    { 18, 3000, 6, new DateTime(2021, 12, 17, 7, 50, 59, 737, DateTimeKind.Local).AddTicks(57), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expense_CategoryId",
                table: "Expense",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_UserId",
                table: "Expense",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expense");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
