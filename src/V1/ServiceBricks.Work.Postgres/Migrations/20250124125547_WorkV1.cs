using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceBricks.Work.Postgres.Migrations
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
                    Key = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ProcessQueue = table.Column<string>(type: "text", nullable: true),
                    ProcessType = table.Column<string>(type: "text", nullable: true),
                    ProcessData = table.Column<string>(type: "text", nullable: true),
                    IsComplete = table.Column<bool>(type: "boolean", nullable: false),
                    IsError = table.Column<bool>(type: "boolean", nullable: false),
                    IsProcessing = table.Column<bool>(type: "boolean", nullable: false),
                    RetryCount = table.Column<int>(type: "integer", nullable: false),
                    ProcessDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    FutureProcessDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ProcessResponse = table.Column<string>(type: "text", nullable: true)
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
