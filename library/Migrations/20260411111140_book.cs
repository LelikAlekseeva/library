using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace library.Migrations
{
    /// <inheritdoc />
    public partial class book : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElectronicAudioBooks_Authors_AuthorId",
                table: "ElectronicAudioBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_ElectronicAudioBooks_ElectronicAudioBooks_ElectronicAudioBookId",
                table: "ElectronicAudioBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ElectronicAudioBooks",
                table: "ElectronicAudioBooks");

            migrationBuilder.RenameTable(
                name: "ElectronicAudioBooks",
                newName: "ElectronicAudioBook");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "ElectronicAudioBook",
                newName: "AuthorID");

            migrationBuilder.RenameIndex(
                name: "IX_ElectronicAudioBooks_ElectronicAudioBookId",
                table: "ElectronicAudioBook",
                newName: "IX_ElectronicAudioBook_ElectronicAudioBookId");

            migrationBuilder.RenameIndex(
                name: "IX_ElectronicAudioBooks_AuthorId",
                table: "ElectronicAudioBook",
                newName: "IX_ElectronicAudioBook_AuthorID");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Readers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Readers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ElectronicAudioBook",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReadersId",
                table: "ElectronicAudioBook",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ElectronicAudioBook",
                table: "ElectronicAudioBook",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ElectronicAudioBook_ReadersId",
                table: "ElectronicAudioBook",
                column: "ReadersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ElectronicAudioBook_Authors_AuthorID",
                table: "ElectronicAudioBook",
                column: "AuthorID",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ElectronicAudioBook_ElectronicAudioBook_ElectronicAudioBookId",
                table: "ElectronicAudioBook",
                column: "ElectronicAudioBookId",
                principalTable: "ElectronicAudioBook",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ElectronicAudioBook_Readers_ReadersId",
                table: "ElectronicAudioBook",
                column: "ReadersId",
                principalTable: "Readers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElectronicAudioBook_Authors_AuthorID",
                table: "ElectronicAudioBook");

            migrationBuilder.DropForeignKey(
                name: "FK_ElectronicAudioBook_ElectronicAudioBook_ElectronicAudioBookId",
                table: "ElectronicAudioBook");

            migrationBuilder.DropForeignKey(
                name: "FK_ElectronicAudioBook_Readers_ReadersId",
                table: "ElectronicAudioBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ElectronicAudioBook",
                table: "ElectronicAudioBook");

            migrationBuilder.DropIndex(
                name: "IX_ElectronicAudioBook_ReadersId",
                table: "ElectronicAudioBook");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Readers");

            migrationBuilder.DropColumn(
                name: "ReadersId",
                table: "ElectronicAudioBook");

            migrationBuilder.RenameTable(
                name: "ElectronicAudioBook",
                newName: "ElectronicAudioBooks");

            migrationBuilder.RenameColumn(
                name: "AuthorID",
                table: "ElectronicAudioBooks",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_ElectronicAudioBook_ElectronicAudioBookId",
                table: "ElectronicAudioBooks",
                newName: "IX_ElectronicAudioBooks_ElectronicAudioBookId");

            migrationBuilder.RenameIndex(
                name: "IX_ElectronicAudioBook_AuthorID",
                table: "ElectronicAudioBooks",
                newName: "IX_ElectronicAudioBooks_AuthorId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Readers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ElectronicAudioBooks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ElectronicAudioBooks",
                table: "ElectronicAudioBooks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ElectronicAudioBooks_Authors_AuthorId",
                table: "ElectronicAudioBooks",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ElectronicAudioBooks_ElectronicAudioBooks_ElectronicAudioBookId",
                table: "ElectronicAudioBooks",
                column: "ElectronicAudioBookId",
                principalTable: "ElectronicAudioBooks",
                principalColumn: "Id");
        }
    }
}
