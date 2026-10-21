using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MenuSemanal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AgregarIdUsuarioAMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idusuario",
                table: "menusemanal",
                type: "integer",
                nullable: false,
                defaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idusuario",
                table: "menusemanal");
        }
    }
}
