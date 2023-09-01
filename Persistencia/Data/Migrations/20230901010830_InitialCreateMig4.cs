using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateMig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trainersalon_persona_IdPerTrainerFk",
                table: "trainersalon");

            migrationBuilder.DropForeignKey(
                name: "FK_trainersalon_salon_IdSalonFk",
                table: "trainersalon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_trainersalon",
                table: "trainersalon");

            migrationBuilder.DropIndex(
                name: "IX_trainersalon_IdSalonFk",
                table: "trainersalon");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "trainersalon");

            migrationBuilder.RenameTable(
                name: "trainersalon",
                newName: "TrainerSalones");

            migrationBuilder.RenameIndex(
                name: "IX_trainersalon_IdPerTrainerFk",
                table: "TrainerSalones",
                newName: "IX_TrainerSalones_IdPerTrainerFk");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainerSalones",
                table: "TrainerSalones",
                columns: new[] { "IdSalonFk", "IdPerTrainerFk" });

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerSalones_persona_IdPerTrainerFk",
                table: "TrainerSalones",
                column: "IdPerTrainerFk",
                principalTable: "persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerSalones_salon_IdSalonFk",
                table: "TrainerSalones",
                column: "IdSalonFk",
                principalTable: "salon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainerSalones_persona_IdPerTrainerFk",
                table: "TrainerSalones");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerSalones_salon_IdSalonFk",
                table: "TrainerSalones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainerSalones",
                table: "TrainerSalones");

            migrationBuilder.RenameTable(
                name: "TrainerSalones",
                newName: "trainersalon");

            migrationBuilder.RenameIndex(
                name: "IX_TrainerSalones_IdPerTrainerFk",
                table: "trainersalon",
                newName: "IX_trainersalon_IdPerTrainerFk");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "trainersalon",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_trainersalon",
                table: "trainersalon",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_trainersalon_IdSalonFk",
                table: "trainersalon",
                column: "IdSalonFk");

            migrationBuilder.AddForeignKey(
                name: "FK_trainersalon_persona_IdPerTrainerFk",
                table: "trainersalon",
                column: "IdPerTrainerFk",
                principalTable: "persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_trainersalon_salon_IdSalonFk",
                table: "trainersalon",
                column: "IdSalonFk",
                principalTable: "salon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
