using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
