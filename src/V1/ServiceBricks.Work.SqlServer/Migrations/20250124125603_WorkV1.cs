using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceBricks.Work.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class WorkV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Work");

            migrationBuilder.CreateTable(
                name: "Process",
                schema: "Work",
                columns: table => new
                {
                    Key = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ProcessQueue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false),
                    IsError = table.Column<bool>(type: "bit", nullable: false),
                    IsProcessing = table.Column<bool>(type: "bit", nullable: false),
                    RetryCount = table.Column<int>(type: "int", nullable: false),
                    ProcessDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    FutureProcessDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ProcessResponse = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Process", x => x.Key);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Process",
                schema: "Work");
        }
    }
}
