using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class asdjasdkasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Mensagem_MensagemId",
                table: "Comentario");

            migrationBuilder.AlterColumn<int>(
                name: "MensagemId",
                table: "Comentario",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Mensagem_MensagemId",
                table: "Comentario",
                column: "MensagemId",
                principalTable: "Mensagem",
                principalColumn: "MensagemId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Mensagem_MensagemId",
                table: "Comentario");

            migrationBuilder.AlterColumn<int>(
                name: "MensagemId",
                table: "Comentario",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Mensagem_MensagemId",
                table: "Comentario",
                column: "MensagemId",
                principalTable: "Mensagem",
                principalColumn: "MensagemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
