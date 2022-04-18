using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFirstApp.Migrations
{
    public partial class AddAmenitiesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    amenityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.amenityId);
                });

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "amenityId", "name" },
                values: new object[,]
                {
                    { 1, "Spa" },
                    { 2, "Toiletries" },
                    { 3, "Shaving Cream" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "hotelId", "address", "city", "name", "phoneNum", "state" },
                values: new object[,]
                {
                    { 1, "5th Circle", "Amman", "Sheraton", "0795396245", "Amman" },
                    { 2, "Abo Shouman Str", "Amman", "Kempinski", "0784326751", "Amman" },
                    { 3, "University Str", "Irbid", "Seven Days", "0774326571", "Irbid" }
                });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "roomId",
                keyValue: 1,
                column: "nickname",
                value: "Special Room");

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "roomId", "layout", "nickname" },
                values: new object[] { 3, "Normal room", "Standard Room" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "hotelId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "hotelId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "hotelId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "roomId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "roomId",
                keyValue: 1,
                column: "nickname",
                value: "the good Room");
        }
    }
}
