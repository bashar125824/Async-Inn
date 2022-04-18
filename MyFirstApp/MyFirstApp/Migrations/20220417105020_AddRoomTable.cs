using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFirstApp.Migrations
{
    public partial class AddRoomTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    roomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    layout = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.roomId);
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "roomId", "layout", "nickname" },
                values: new object[] { 1, "master room", "the good Room" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "roomId", "layout", "nickname" },
                values: new object[] { 2, "Room with a big pool", "VIP Room" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
