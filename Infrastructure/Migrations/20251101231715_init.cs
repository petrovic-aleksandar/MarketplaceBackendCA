using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Marketplace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiry = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Createtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_ItemType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ItemType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Item_User_SellerId",
                        column: x => x.SellerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    IsFront = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transfer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    BuyerId = table.Column<int>(type: "int", nullable: true),
                    SellerId = table.Column<int>(type: "int", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transfer_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transfer_User_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transfer_User_SellerId",
                        column: x => x.SellerId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ItemType",
                columns: new[] { "Id", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { 1, "Cars and other transportation. Scooters, bikes, trains, boats, yachts, airships..", "Categories/1.jpg", "Cars&Vehicles" },
                    { 2, "Everything for your home, small home and kitchen electronics.", "Categories/2.jpg", "Home&Kitchen" },
                    { 3, "All kinds of devices. Gaming equipment, laptops, home appliances etc.", "Categories/3.jpg", "Electronics" },
                    { 4, "Sports clothing and sport requisits", "Categories/4.jpg", "Sports&Outdoors" },
                    { 5, "Everything for women.", "Categories/5.jpg", "Women's clothing" },
                    { 6, "All kinds of jewelry and decorative items.", "Categories/6.jpg", "Jewelry&Accesories" },
                    { 7, "Clothing items for men.", "Categories/7.jpg", "Mens's clothing" },
                    { 8, "Books and stuff.", "Categories/8.jpg", "Books&Media" },
                    { 9, "For various intelectual or physical services.", "Categories/9.jpg", "Services" },
                    { 10, "Whatever else.", "Categories/10.jpg", "Other" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Balance", "Email", "IsActive", "Name", "Password", "Phone", "RefreshToken", "RefreshTokenExpiry", "Role", "Salt", "Username" },
                values: new object[,]
                {
                    { 1, 0.0, "aa@gmail.com", true, "John Doe", "eUS8Chai2BphVYD54jXg24iRP80n2XLBCf5klkgVNGSYr5xCvG05DnHPTRGBxK2q", "67 407648", null, null, 1, "eUS8Chai2BphVYD54jXg2w==", "admin" },
                    { 2, 0.0, "pp@gmail.com", true, "Peter Petrovich", "qwbR24euiRkhKRT2Rm5l9DCbmk/euQ460gB8D4N0tZGXhfdfSiaR+VT5STBp2hI9", "+382 67 111 222", null, null, 0, "qwbR24euiRkhKRT2Rm5l9A==", "peter" },
                    { 3, 1000000.0, "gr@gmail.com", true, "Guy Rich", "eUS8Chai2BphVYD54jXg24iRP80n2XLBCf5klkgVNGSYr5xCvG05DnHPTRGBxK2q", "+382 67 101 909", null, null, 0, "eUS8Chai2BphVYD54jXg2w==", "rich" }
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "Createtime", "Description", "IsActive", "IsDeleted", "Name", "Price", "SellerId", "TypeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 23, 20, 9, 22, 298, DateTimeKind.Local).AddTicks(7972), "Red color, 2021., 35 TFSI", true, false, "Audi A4", 35000.0, 2, 1 },
                    { 2, new DateTime(2025, 10, 23, 20, 9, 22, 298, DateTimeKind.Local).AddTicks(7972), "A5 new model, 2021., 40 TFSI", true, false, "Audi A5", 45000.0, 2, 1 },
                    { 3, new DateTime(2025, 10, 23, 20, 9, 22, 298, DateTimeKind.Local).AddTicks(7972), "SUV model, 2021., 45 TFSI", true, false, "Audi Q5", 65000.0, 2, 1 },
                    { 4, new DateTime(2025, 10, 23, 20, 9, 22, 298, DateTimeKind.Local).AddTicks(7972), "Classic audi, 2016., 3.0 gasoline", true, false, "Audi TT", 15000.0, 2, 1 },
                    { 5, new DateTime(2025, 10, 23, 20, 9, 22, 298, DateTimeKind.Local).AddTicks(7972), "Yellow color, 2014., 35 TFSI", true, false, "Lotus Elise", 30000.0, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "IsFront", "ItemId", "Path" },
                values: new object[,]
                {
                    { 1, true, 1, "audi_a4.jpg" },
                    { 2, false, 1, "audi_a4_2.jpg" },
                    { 3, false, 1, "audi_a4_3.jpg" },
                    { 4, true, 2, "audi_a5.jpg" },
                    { 5, true, 3, "audi_q5.jpg" },
                    { 6, true, 4, "audi_tt.jpg" },
                    { 7, true, 5, "lotuselise.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Image_ItemId",
                table: "Image",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_SellerId",
                table: "Item",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_TypeId",
                table: "Item",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfer_BuyerId",
                table: "Transfer",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfer_ItemId",
                table: "Transfer",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfer_SellerId",
                table: "Transfer",
                column: "SellerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Transfer");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "ItemType");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
