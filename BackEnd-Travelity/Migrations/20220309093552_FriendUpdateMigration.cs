using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd_Travelity.Migrations
{
    public partial class FriendUpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Yes_No",
                table: "Friend");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Friend",
                newName: "User_Username");

            migrationBuilder.AddColumn<int>(
                name: "FriendRequestId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Friend",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Friend_Username",
                table: "Friend",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "FriendRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Receiver = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendRequest", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_FriendRequestId",
                table: "User",
                column: "FriendRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_FriendRequest_FriendRequestId",
                table: "User",
                column: "FriendRequestId",
                principalTable: "FriendRequest",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_FriendRequest_FriendRequestId",
                table: "User");

            migrationBuilder.DropTable(
                name: "FriendRequest");

            migrationBuilder.DropIndex(
                name: "IX_User_FriendRequestId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FriendRequestId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Friend");

            migrationBuilder.DropColumn(
                name: "Friend_Username",
                table: "Friend");

            migrationBuilder.RenameColumn(
                name: "User_Username",
                table: "Friend",
                newName: "Name");

            migrationBuilder.AddColumn<bool>(
                name: "Yes_No",
                table: "Friend",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
