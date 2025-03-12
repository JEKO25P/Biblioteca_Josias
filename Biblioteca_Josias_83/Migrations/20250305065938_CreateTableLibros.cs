using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca_Josias_83.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableLibros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnioPublicacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "PkRol",
                keyValue: 1,
                column: "Nombre",
                value: "Admin");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "PkRol", "Nombre" },
                values: new object[] { 2, "Usuario" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "PkUsuario",
                keyValue: 1,
                column: "UserName",
                value: "admin");

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "PkUsuario", "FkRol", "Nombre", "Password", "UserName" },
                values: new object[] { 2, 2, "Usuario", "123", "user" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "PkUsuario",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "PkRol",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "PkRol",
                keyValue: 1,
                column: "Nombre",
                value: "sa");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "PkUsuario",
                keyValue: 1,
                column: "UserName",
                value: "Usuario");
        }
    }
}
