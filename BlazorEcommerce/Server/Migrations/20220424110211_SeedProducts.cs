using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorEcommerce.Server.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[] { 1, "The Hitchhiker's Guide to the Galaxy[note 1] (sometimes referred to as HG2G,[1] HHGTTG,[2] H2G2,[3] or tHGttG) is a comedy science fiction franchise created by Douglas Adams. Originally a 1978 radio comedy broadcast on BBC Radio 4, it was later adapted to other formats, including stage shows, novels, comic books, a 1981 TV series, a 1984 text-based computer game, and 2005 feature film.", "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg", 3.99m, "The Hitchhiker's Guide to the Galaxy" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[] { 2, "Along with the series Notes of a Dirty Old Man, Portions from a Wine-Stained Notebook includes another deep look into Charles Bukowski's life. It is a lengthened version of Notes of a Dirty Old Man that is more of an autobiography about him becoming a writer than a short story. It is called A Dirty Old Man Confesses.", "https://upload.wikimedia.org/wikipedia/en/d/dd/NotesOfADirtyOldMan.jpg", 6.99m, "Notes of a Dirty Old Man" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[] { 3, "Red Rising is a 2014 dystopian science fiction novel by American author Pierce Brown, and the first book and eponym of a series. The novel, set on a future planet Mars, follows lowborn miner Darrow as he infiltrates the ranks of the elite Golds.", "https://upload.wikimedia.org/wikipedia/en/9/9b/Red_Rising_%282014%29.jpg", 5.99m, "Red Rising" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
