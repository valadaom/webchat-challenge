using Microsoft.EntityFrameworkCore.Migrations;

namespace jobsity_chat_app.Migrations
{
    public partial class updateRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Users_UserId",
                table: "Message");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Message",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Users_UserId",
                table: "Message",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Users_UserId",
                table: "Message");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Message",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Users_UserId",
                table: "Message",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
