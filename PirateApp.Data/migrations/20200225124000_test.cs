using Microsoft.EntityFrameworkCore.Migrations;

namespace PirateApp.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PirateDuel_Duel_DuelId",
                table: "PirateDuel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PirateDuel",
                table: "PirateDuel");

            migrationBuilder.DropColumn(
                name: "BattleId",
                table: "PirateDuel");

            migrationBuilder.AlterColumn<int>(
                name: "DuelId",
                table: "PirateDuel",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PirateDuel",
                table: "PirateDuel",
                columns: new[] { "PirateId", "DuelId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PirateDuel_Duel_DuelId",
                table: "PirateDuel",
                column: "DuelId",
                principalTable: "Duel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PirateDuel_Duel_DuelId",
                table: "PirateDuel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PirateDuel",
                table: "PirateDuel");

            migrationBuilder.AlterColumn<int>(
                name: "DuelId",
                table: "PirateDuel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "BattleId",
                table: "PirateDuel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PirateDuel",
                table: "PirateDuel",
                columns: new[] { "PirateId", "BattleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PirateDuel_Duel_DuelId",
                table: "PirateDuel",
                column: "DuelId",
                principalTable: "Duel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
