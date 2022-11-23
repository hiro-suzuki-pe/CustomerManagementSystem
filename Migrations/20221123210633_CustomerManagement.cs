using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class CustomerManagement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customername = table.Column<string>(name: "customer_name", type: "nvarchar(max)", nullable: false),
                    customerkana = table.Column<string>(name: "customer_kana", type: "nvarchar(max)", nullable: false),
                    companyId = table.Column<int>(type: "int", nullable: false),
                    section = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    post = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    zipcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    staffId = table.Column<int>(type: "int", nullable: false),
                    firstactiondate = table.Column<DateTime>(name: "first_action_date", type: "datetime2", nullable: false),
                    memo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    inputdate = table.Column<DateTime>(name: "input_date", type: "datetime2", nullable: false),
                    inputstaffname = table.Column<string>(name: "input_staff_name", type: "nvarchar(max)", nullable: false),
                    updatedate = table.Column<DateTime>(name: "update_date", type: "datetime2", nullable: false),
                    updatestaffname = table.Column<string>(name: "update_staff_name", type: "nvarchar(max)", nullable: false),
                    deleteflag = table.Column<bool>(name: "delete_flag", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SampleId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Book_SampleId",
                        column: x => x.SampleId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_SampleId",
                table: "Book",
                column: "SampleId");
        }
    }
}
