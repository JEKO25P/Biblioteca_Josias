using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca_Josias_83.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    PkAutor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.PkAutor);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    PkCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.PkCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    PkRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.PkRol);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    PkLibro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagen = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AñoPublicacion = table.Column<int>(type: "int", nullable: false),
                    Editorial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlLectura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FkCategoria = table.Column<int>(type: "int", nullable: false),
                    FkAutor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.PkLibro);
                    table.ForeignKey(
                        name: "FK_Libros_Autores_FkAutor",
                        column: x => x.FkAutor,
                        principalTable: "Autores",
                        principalColumn: "PkAutor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Libros_Categorias_FkCategoria",
                        column: x => x.FkCategoria,
                        principalTable: "Categorias",
                        principalColumn: "PkCategoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    PkUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FkRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.PkUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_FkRol",
                        column: x => x.FkRol,
                        principalTable: "Roles",
                        principalColumn: "PkRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LibrosCategorias",
                columns: table => new
                {
                    PkLibrosCategorias = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkLibro = table.Column<int>(type: "int", nullable: false),
                    FkCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibrosCategorias", x => x.PkLibrosCategorias);
                    table.ForeignKey(
                        name: "FK_LibrosCategorias_Categorias_FkCategoria",
                        column: x => x.FkCategoria,
                        principalTable: "Categorias",
                        principalColumn: "PkCategoria");
                    table.ForeignKey(
                        name: "FK_LibrosCategorias_Libros_FkLibro",
                        column: x => x.FkLibro,
                        principalTable: "Libros",
                        principalColumn: "PkLibro");
                });

            migrationBuilder.CreateTable(
                name: "Favoritos",
                columns: table => new
                {
                    PKFavorito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkUsuario = table.Column<int>(type: "int", nullable: false),
                    UsuarioPkUsuario = table.Column<int>(type: "int", nullable: false),
                    FkLibro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoritos", x => x.PKFavorito);
                    table.ForeignKey(
                        name: "FK_Favoritos_Libros_FkLibro",
                        column: x => x.FkLibro,
                        principalTable: "Libros",
                        principalColumn: "PkLibro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favoritos_Usuarios_UsuarioPkUsuario",
                        column: x => x.UsuarioPkUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "PkUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_FkLibro",
                table: "Favoritos",
                column: "FkLibro");

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_UsuarioPkUsuario",
                table: "Favoritos",
                column: "UsuarioPkUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_FkAutor",
                table: "Libros",
                column: "FkAutor");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_FkCategoria",
                table: "Libros",
                column: "FkCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_LibrosCategorias_FkCategoria",
                table: "LibrosCategorias",
                column: "FkCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_LibrosCategorias_FkLibro",
                table: "LibrosCategorias",
                column: "FkLibro");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_FkRol",
                table: "Usuarios",
                column: "FkRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favoritos");

            migrationBuilder.DropTable(
                name: "LibrosCategorias");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
