using Microsoft.EntityFrameworkCore.Migrations;

namespace ExtraClasses.Persistence.Migrations
{
    public partial class added_paid_column_to_bookings_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Paid",
                table: "Booking",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Paid",
                table: "Booking");
        }
    }
}
