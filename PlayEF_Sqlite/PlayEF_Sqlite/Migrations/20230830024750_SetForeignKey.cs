using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayEF_Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class SetForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Cards_ThoughtId",
                table: "Cards",
                column: "ThoughtId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Thoughts_ThoughtId",
                table: "Cards",
                column: "ThoughtId",
                principalTable: "Thoughts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Thoughts_ThoughtId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_ThoughtId",
                table: "Cards");
        }
    }
}
