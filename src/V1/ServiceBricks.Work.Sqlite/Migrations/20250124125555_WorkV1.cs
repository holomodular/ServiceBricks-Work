using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceBricks.Work.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class WorkV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Process",
                columns: table => new
                {
                    Key = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreateDate = table.Column<byte[]>(type: "BLOB", nullable: false),
                    UpdateDate = table.Column<byte[]>(type: "BLOB", nullable: false),
                    ProcessQueue = table.Column<string>(type: "TEXT", nullable: true),
                    ProcessType = table.Column<string>(type: "TEXT", nullable: true),
                    ProcessData = table.Column<string>(type: "TEXT", nullable: true),
                    IsComplete = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsError = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsProcessing = table.Column<bool>(type: "INTEGER", nullable: false),
                    RetryCount = table.Column<int>(type: "INTEGER", nullable: false),
                    ProcessDate = table.Column<byte[]>(type: "BLOB", nullable: false),
                    FutureProcessDate = table.Column<byte[]>(type: "BLOB", nullable: false),
                    ProcessResponse = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "Process");
        }
    }
}
