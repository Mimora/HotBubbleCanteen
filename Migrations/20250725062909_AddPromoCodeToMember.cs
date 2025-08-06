using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotBubbleCanteen.Migrations
{
    /// <inheritdoc />
    public partial class AddPromoCodeToMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PromoCode",
                table: "Members",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PromoCode",
                table: "Members");
        }
    }
}
