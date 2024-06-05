using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC4m19d.Migrations
{
    /// <inheritdoc />
    public partial class updateid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Articles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "(uuid())",
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Articles",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "(uuid())")
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
