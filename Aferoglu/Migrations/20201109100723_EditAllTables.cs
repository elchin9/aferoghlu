using Microsoft.EntityFrameworkCore.Migrations;

namespace Aferoglu.Migrations
{
    public partial class EditAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "StaticData");

            migrationBuilder.DropColumn(
                name: "WorkingHours",
                table: "StaticData");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "Header",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Maifacturer",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "OurTeam");

            migrationBuilder.DropColumn(
                name: "Profession",
                table: "OurTeam");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AferogluHistory");

            migrationBuilder.DropColumn(
                name: "Header",
                table: "AferogluHistory");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "About");

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AferogluHistoryLangs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    AferogluHistoryId = table.Column<int>(nullable: false),
                    LangId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AferogluHistoryLangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AferogluHistoryLangs_AferogluHistory_AferogluHistoryId",
                        column: x => x.AferogluHistoryId,
                        principalTable: "AferogluHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AferogluHistoryLangs_Langs_LangId",
                        column: x => x.LangId,
                        principalTable: "Langs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryLangs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    LangId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryLangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryLangs_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryLangs_Langs_LangId",
                        column: x => x.LangId,
                        principalTable: "Langs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OurTeamLangs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: false),
                    Profession = table.Column<string>(nullable: false),
                    OurTeamId = table.Column<int>(nullable: false),
                    LangId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurTeamLangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OurTeamLangs_Langs_LangId",
                        column: x => x.LangId,
                        principalTable: "Langs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OurTeamLangs_OurTeam_OurTeamId",
                        column: x => x.OurTeamId,
                        principalTable: "OurTeam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductLangs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Maifacturer = table.Column<string>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    LangId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductLangs_Langs_LangId",
                        column: x => x.LangId,
                        principalTable: "Langs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductLangs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SliderLangs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    SliderId = table.Column<int>(nullable: false),
                    LangId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SliderLangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SliderLangs_Langs_LangId",
                        column: x => x.LangId,
                        principalTable: "Langs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SliderLangs_Sliders_SliderId",
                        column: x => x.SliderId,
                        principalTable: "Sliders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaticDataLangs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(nullable: false),
                    WorkingHours = table.Column<string>(nullable: true),
                    StaticDataId = table.Column<int>(nullable: false),
                    LangId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaticDataLangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaticDataLangs_Langs_LangId",
                        column: x => x.LangId,
                        principalTable: "Langs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaticDataLangs_StaticData_StaticDataId",
                        column: x => x.StaticDataId,
                        principalTable: "StaticData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestimonialsLangs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(nullable: false),
                    TestimonialsId = table.Column<int>(nullable: false),
                    LangId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestimonialsLangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestimonialsLangs_Langs_LangId",
                        column: x => x.LangId,
                        principalTable: "Langs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestimonialsLangs_Testimonials_TestimonialsId",
                        column: x => x.TestimonialsId,
                        principalTable: "Testimonials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AferogluHistoryLangs_AferogluHistoryId",
                table: "AferogluHistoryLangs",
                column: "AferogluHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AferogluHistoryLangs_LangId",
                table: "AferogluHistoryLangs",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryLangs_CategoryId",
                table: "CategoryLangs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryLangs_LangId",
                table: "CategoryLangs",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_OurTeamLangs_LangId",
                table: "OurTeamLangs",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_OurTeamLangs_OurTeamId",
                table: "OurTeamLangs",
                column: "OurTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLangs_LangId",
                table: "ProductLangs",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLangs_ProductId",
                table: "ProductLangs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SliderLangs_LangId",
                table: "SliderLangs",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_SliderLangs_SliderId",
                table: "SliderLangs",
                column: "SliderId");

            migrationBuilder.CreateIndex(
                name: "IX_StaticDataLangs_LangId",
                table: "StaticDataLangs",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_StaticDataLangs_StaticDataId",
                table: "StaticDataLangs",
                column: "StaticDataId");

            migrationBuilder.CreateIndex(
                name: "IX_TestimonialsLangs_LangId",
                table: "TestimonialsLangs",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_TestimonialsLangs_TestimonialsId",
                table: "TestimonialsLangs",
                column: "TestimonialsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AferogluHistoryLangs");

            migrationBuilder.DropTable(
                name: "CategoryLangs");

            migrationBuilder.DropTable(
                name: "OurTeamLangs");

            migrationBuilder.DropTable(
                name: "ProductLangs");

            migrationBuilder.DropTable(
                name: "SliderLangs");

            migrationBuilder.DropTable(
                name: "StaticDataLangs");

            migrationBuilder.DropTable(
                name: "TestimonialsLangs");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Testimonials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Testimonials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "StaticData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WorkingHours",
                table: "StaticData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Header",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Maifacturer",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "OurTeam",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Profession",
                table: "OurTeam",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AferogluHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Header",
                table: "AferogluHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "About",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
