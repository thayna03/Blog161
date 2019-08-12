using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog4.Migrations
{
    public partial class Blog123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Mensagem_MensagemId",
                table: "Comentario");

            migrationBuilder.DropIndex(
                name: "IX_Comentario_MensagemId",
                table: "Comentario");

            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Mensagem");

            migrationBuilder.DropColumn(
                name: "MensagemId",
                table: "Comentario");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Mensagem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ComentarioId",
                table: "Mensagem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Comentario",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_CategoriaId",
                table: "Mensagem",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_ComentarioId",
                table: "Mensagem",
                column: "ComentarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mensagem_Categoria_CategoriaId",
                table: "Mensagem",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mensagem_Comentario_ComentarioId",
                table: "Mensagem",
                column: "ComentarioId",
                principalTable: "Comentario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mensagem_Categoria_CategoriaId",
                table: "Mensagem");

            migrationBuilder.DropForeignKey(
                name: "FK_Mensagem_Comentario_ComentarioId",
                table: "Mensagem");

            migrationBuilder.DropIndex(
                name: "IX_Mensagem_CategoriaId",
                table: "Mensagem");

            migrationBuilder.DropIndex(
                name: "IX_Mensagem_ComentarioId",
                table: "Mensagem");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Mensagem");

            migrationBuilder.DropColumn(
                name: "ComentarioId",
                table: "Mensagem");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Comentario");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Mensagem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MensagemId",
                table: "Comentario",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_MensagemId",
                table: "Comentario",
                column: "MensagemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Mensagem_MensagemId",
                table: "Comentario",
                column: "MensagemId",
                principalTable: "Mensagem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
