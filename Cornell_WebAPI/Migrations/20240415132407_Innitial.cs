using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cornell_WebAPI.Migrations
{
    public partial class Innitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientdetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NIN_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelephoneNo = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateRegistered = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DatePlacement = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CountryPlacement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientdetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countriesdetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Flag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countriesdetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employerdetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employerdetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enumeratorsdetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NIN_No = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateRegistered = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProfilePic = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enumeratorsdetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobdetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobdetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Placementdetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientdetailsId = table.Column<int>(type: "int", nullable: true),
                    JobofferId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Placementdetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Placementdetails_Clientdetails_ClientdetailsId",
                        column: x => x.ClientdetailsId,
                        principalTable: "Clientdetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Placementdetails_Jobdetails_JobofferId",
                        column: x => x.JobofferId,
                        principalTable: "Jobdetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Placementdetails_ClientdetailsId",
                table: "Placementdetails",
                column: "ClientdetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Placementdetails_JobofferId",
                table: "Placementdetails",
                column: "JobofferId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countriesdetails");

            migrationBuilder.DropTable(
                name: "Employerdetails");

            migrationBuilder.DropTable(
                name: "Enumeratorsdetails");

            migrationBuilder.DropTable(
                name: "Placementdetails");

            migrationBuilder.DropTable(
                name: "Clientdetails");

            migrationBuilder.DropTable(
                name: "Jobdetails");
        }
    }
}
