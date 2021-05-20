
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoMVCCSHARP.Migrations
{
    public partial class Imagem:Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Noticia",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy",MySqlValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(nullable: true),
                    Resumo = table.Column<string>(nullable: true),
                    Conteudo = table.Column<string>(nullable: true),
                    ImagemName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noticia",x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Noticia");
        }
    }
}