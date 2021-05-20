using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoMVCCSHARP.Migrations
{
    public partial class Imagem2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Imagem",
                table: "Noticia",
                newName: "ImagemName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagemName",
                table: "Noticia",
                newName: "Imagem");
        }
    }
}
