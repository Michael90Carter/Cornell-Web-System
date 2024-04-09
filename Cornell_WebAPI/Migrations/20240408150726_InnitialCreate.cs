using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cornell_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class InnitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientdetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    LastName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Gender = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    NIN_No = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    TelephoneNo = table.Column<int>(type: "int", fixedLength: true, maxLength: 10, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: true),
                    DateRegistered = table.Column<DateTime>(type: "date", nullable: true),
                    DatePlacement = table.Column<DateTime>(type: "date", nullable: true),
                    CountryPlacement = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    ProfilePic = table.Column<byte[]>(type: "varbinary(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Clientd__3214EC07C352B717", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countriesdetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Flag = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    CountryCode = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    CountryName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Status = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Countriesd__3214EC07C352B718", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enumeratorsdetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    LastName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Gender = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    NIN_No = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Department = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Email = table.Column<string>(type: "char(10)", fixedLength: true, maxLength: 10, nullable: true),
                    DateRegistered = table.Column<DateTime>(type: "date", nullable: true),
                    ProfilePic = table.Column<byte[]>(type: "varbinary(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Enumeratorsd__3214EC07C352B719", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientdetails");

            migrationBuilder.DropTable(
                name: "Countriesdetails");

            migrationBuilder.DropTable(
                name: "Enumeratorsdetails");
        }
    }
}
