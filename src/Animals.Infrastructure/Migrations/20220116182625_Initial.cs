using Microsoft.EntityFrameworkCore.Migrations;

namespace Animals.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TailLengt = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Color", "Name", "TailLengt", "Weight" },
                values: new object[] { "b3b78aeb-e332-4930-9134-26daadaced67", "red & amber", "Neo", 22, 32 });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Color", "Name", "TailLengt", "Weight" },
                values: new object[] { "6f9dde9a-34ef-40b5-88bc-c5458e7940db", "black & white", "Jessy", 7, 14 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dogs");
        }
    }
}
