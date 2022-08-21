using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoObservables.Api.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HFlowdata",
                table: "HFlowdata");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "HFlowdata",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HFlowdata",
                table: "HFlowdata",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_HFlowdata_idUserCreate",
                table: "HFlowdata",
                column: "idUserCreate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HFlowdata",
                table: "HFlowdata");

            migrationBuilder.DropIndex(
                name: "IX_HFlowdata_idUserCreate",
                table: "HFlowdata");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "HFlowdata",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HFlowdata",
                table: "HFlowdata",
                columns: new[] { "idUserCreate", "idOrigin" });
        }
    }
}
