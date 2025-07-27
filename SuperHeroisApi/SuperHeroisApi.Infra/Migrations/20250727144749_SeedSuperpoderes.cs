using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SuperHeroisApi.Infra.Migrations
{
    /// <inheritdoc />
    public partial class SeedSuperpoderes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Superpoderes",
                columns: new[] { "Id", "Descricao", "Superpoder" },
                values: new object[,]
                {
                    { 1, "Capacidade de exercer força física muito além dos limites humanos.", "Força Sobre-Humana" },
                    { 2, "Habilidade de voar sem ajuda de equipamentos.", "Voo" },
                    { 3, "Capacidade de ler ou comunicar-se com a mente de outras pessoas.", "Telepatia" },
                    { 4, "Capacidade de tornar o corpo invisível à visão humana.", "Invisibilidade" },
                    { 5, "Habilidade de desacelerar, acelerar ou parar o tempo temporariamente.", "Manipulação do Tempo" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Superpoderes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Superpoderes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Superpoderes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Superpoderes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Superpoderes",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
