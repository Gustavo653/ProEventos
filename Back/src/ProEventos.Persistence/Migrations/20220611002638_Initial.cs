using Microsoft.EntityFrameworkCore.Migrations;

namespace ProEventos.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductFilter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFilter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductFilterItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ParentId = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFilterItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductFilterItem_ProductFilter_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ProductFilter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductSubGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    GroupId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSubGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSubGroup_ProductGroup_GroupId",
                        column: x => x.GroupId,
                        principalTable: "ProductGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    Weight = table.Column<decimal>(type: "TEXT", nullable: false),
                    ProductSubGroupId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductSubGroup_ProductSubGroupId",
                        column: x => x.ProductSubGroupId,
                        principalTable: "ProductSubGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FilterId = table.Column<int>(type: "INTEGER", nullable: true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: true),
                    Item = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductConfiguration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductConfiguration_ProductFilter_FilterId",
                        column: x => x.FilterId,
                        principalTable: "ProductFilter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductConfiguration_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductGrade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: true),
                    Item1Id = table.Column<int>(type: "INTEGER", nullable: true),
                    Item2Id = table.Column<int>(type: "INTEGER", nullable: true),
                    Item3Id = table.Column<int>(type: "INTEGER", nullable: true),
                    Item4Id = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGrade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductGrade_ProductFilter_Item1Id",
                        column: x => x.Item1Id,
                        principalTable: "ProductFilter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductGrade_ProductFilter_Item2Id",
                        column: x => x.Item2Id,
                        principalTable: "ProductFilter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductGrade_ProductFilter_Item3Id",
                        column: x => x.Item3Id,
                        principalTable: "ProductFilter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductGrade_ProductFilter_Item4Id",
                        column: x => x.Item4Id,
                        principalTable: "ProductFilter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductGrade_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductConfiguration_FilterId",
                table: "ProductConfiguration",
                column: "FilterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductConfiguration_ProductId",
                table: "ProductConfiguration",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFilterItem_ParentId",
                table: "ProductFilterItem",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGrade_Item1Id",
                table: "ProductGrade",
                column: "Item1Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGrade_Item2Id",
                table: "ProductGrade",
                column: "Item2Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGrade_Item3Id",
                table: "ProductGrade",
                column: "Item3Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGrade_Item4Id",
                table: "ProductGrade",
                column: "Item4Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGrade_ProductId",
                table: "ProductGrade",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductSubGroupId",
                table: "Products",
                column: "ProductSubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSubGroup_GroupId",
                table: "ProductSubGroup",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductConfiguration");

            migrationBuilder.DropTable(
                name: "ProductFilterItem");

            migrationBuilder.DropTable(
                name: "ProductGrade");

            migrationBuilder.DropTable(
                name: "ProductFilter");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductSubGroup");

            migrationBuilder.DropTable(
                name: "ProductGroup");
        }
    }
}
