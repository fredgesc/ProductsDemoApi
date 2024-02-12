using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsDemoApi.Migrations
{
    public partial class DefaultValueForProductsReviewers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReviewerName",
                table: "ProductReviews",
                type: "VARCHAR(200)",
                nullable: false,
                defaultValue: "(Anonymous)",
                oldClrType: typeof(string),
                oldType: "VARCHAR(200)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReviewerName",
                table: "ProductReviews",
                type: "VARCHAR(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(200)",
                oldDefaultValue: "(Anonymous)");
        }
    }
}
