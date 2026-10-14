using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MenuSemanal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AgregarOpcionesYDefaultsPlatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "fotourl",
                table: "platos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "fechacreacion",
                table: "platos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_DATE",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "fotourl",
                table: "platos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "fechacreacion",
                table: "platos",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_DATE");
        }
    }
}
