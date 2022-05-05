using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class deneme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DistrictName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConstructionYear = table.Column<int>(type: "int", nullable: false),
                    NumberOfRooms = table.Column<int>(type: "int", nullable: false),
                    NumberOfBath = table.Column<int>(type: "int", nullable: false),
                    SquareMeter = table.Column<int>(type: "int", nullable: false),
                    SalesCategoryId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    SalesTypeId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 5, 5, 17, 33, 11, 508, DateTimeKind.Local).AddTicks(8153)),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 5, 5, 17, 33, 11, 513, DateTimeKind.Local).AddTicks(2293)),
                    Advertiser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Houses_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Houses_SalesCategories_SalesCategoryId",
                        column: x => x.SalesCategoryId,
                        principalTable: "SalesCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Houses_SalesTypes_SalesTypeId",
                        column: x => x.SalesTypeId,
                        principalTable: "SalesTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(type: "int", nullable: false),
                    SquareMeter = table.Column<int>(type: "int", nullable: false),
                    SalesCategoryId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    SalesTypeId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 5, 5, 17, 33, 11, 515, DateTimeKind.Local).AddTicks(7327)),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 5, 5, 17, 33, 11, 515, DateTimeKind.Local).AddTicks(8697)),
                    Advertiser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lands_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lands_SalesCategories_SalesCategoryId",
                        column: x => x.SalesCategoryId,
                        principalTable: "SalesCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lands_SalesTypes_SalesTypeId",
                        column: x => x.SalesTypeId,
                        principalTable: "SalesTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkPlaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(type: "int", nullable: false),
                    SquareMeter = table.Column<int>(type: "int", nullable: false),
                    SalesCategoryId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    SalesTypeId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 5, 5, 17, 33, 11, 517, DateTimeKind.Local).AddTicks(8627)),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 5, 5, 17, 33, 11, 517, DateTimeKind.Local).AddTicks(9700)),
                    Advertiser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPlaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkPlaces_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkPlaces_SalesCategories_SalesCategoryId",
                        column: x => x.SalesCategoryId,
                        principalTable: "SalesCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkPlaces_SalesTypes_SalesTypeId",
                        column: x => x.SalesTypeId,
                        principalTable: "SalesTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HouseImageUrls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseImageUrls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseImageUrls_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LandImageUrls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandImageUrls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LandImageUrls_Lands_LandId",
                        column: x => x.LandId,
                        principalTable: "Lands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkPlaceImageUrls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkPlaceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPlaceImageUrls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkPlaceImageUrls_WorkPlaces_WorkPlaceId",
                        column: x => x.WorkPlaceId,
                        principalTable: "WorkPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "CityName", "DistrictName" },
                values: new object[,]
                {
                    { 1, "karaman", "merkez" },
                    { 12, "mersin", "toroslar" },
                    { 11, "mersin", "mut" },
                    { 10, "mersin", "çiftlikköy" },
                    { 8, "mersin", "silifke" },
                    { 7, "mersin", "mezitli" },
                    { 9, "mersin", "yenişehir" },
                    { 5, "konya", "meram" },
                    { 4, "karaman", "kazımkarabekir" },
                    { 3, "karaman", "ermenek" },
                    { 2, "karaman", "Ayrancı" },
                    { 6, "konya", "selçuklu" }
                });

            migrationBuilder.InsertData(
                table: "SalesCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 9, "dükkan" },
                    { 13, "büro" },
                    { 12, "plaza" },
                    { 11, "fabrika" },
                    { 10, "ofis" },
                    { 8, "zeytinlik" },
                    { 3, "site" },
                    { 6, "tarla" },
                    { 5, "yazlık" },
                    { 4, "villa" },
                    { 2, "müstakil" },
                    { 1, "apartman" },
                    { 7, "bağ" }
                });

            migrationBuilder.InsertData(
                table: "SalesTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "günlük kiralık" },
                    { 1, "satılık" },
                    { 2, "kiralık" },
                    { 4, "sezonluk" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HouseImageUrls_HouseId",
                table: "HouseImageUrls",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_LocationId",
                table: "Houses",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_SalesCategoryId",
                table: "Houses",
                column: "SalesCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_SalesTypeId",
                table: "Houses",
                column: "SalesTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LandImageUrls_LandId",
                table: "LandImageUrls",
                column: "LandId");

            migrationBuilder.CreateIndex(
                name: "IX_Lands_LocationId",
                table: "Lands",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Lands_SalesCategoryId",
                table: "Lands",
                column: "SalesCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Lands_SalesTypeId",
                table: "Lands",
                column: "SalesTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPlaceImageUrls_WorkPlaceId",
                table: "WorkPlaceImageUrls",
                column: "WorkPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPlaces_LocationId",
                table: "WorkPlaces",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPlaces_SalesCategoryId",
                table: "WorkPlaces",
                column: "SalesCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPlaces_SalesTypeId",
                table: "WorkPlaces",
                column: "SalesTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HouseImageUrls");

            migrationBuilder.DropTable(
                name: "LandImageUrls");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WorkPlaceImageUrls");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Lands");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "WorkPlaces");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "SalesCategories");

            migrationBuilder.DropTable(
                name: "SalesTypes");
        }
    }
}
