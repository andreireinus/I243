using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Vault.DataBase.Migrations
{
    public partial class Updaterequirements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LendingRecord_Books_BookId",
                table: "LendingRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_LendingRecord_Lenders_LenderId",
                table: "LendingRecord");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Locations",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LenderId",
                table: "LendingRecord",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "LendingRecord",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Lenders",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Lenders",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LendingRecord_Books_BookId",
                table: "LendingRecord",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LendingRecord_Lenders_LenderId",
                table: "LendingRecord",
                column: "LenderId",
                principalTable: "Lenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LendingRecord_Books_BookId",
                table: "LendingRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_LendingRecord_Lenders_LenderId",
                table: "LendingRecord");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Locations",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "LenderId",
                table: "LendingRecord",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "LendingRecord",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Lenders",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Lenders",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_LendingRecord_Books_BookId",
                table: "LendingRecord",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LendingRecord_Lenders_LenderId",
                table: "LendingRecord",
                column: "LenderId",
                principalTable: "Lenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
