using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class secondupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Freelancers_CustomerID",
                table: "Jobs");

            migrationBuilder.AlterColumn<int>(
                name: "FreelancerID",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_FreelancerID",
                table: "Jobs",
                column: "FreelancerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Freelancers_FreelancerID",
                table: "Jobs",
                column: "FreelancerID",
                principalTable: "Freelancers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Freelancers_FreelancerID",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_FreelancerID",
                table: "Jobs");

            migrationBuilder.AlterColumn<int>(
                name: "FreelancerID",
                table: "Jobs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Freelancers_CustomerID",
                table: "Jobs",
                column: "CustomerID",
                principalTable: "Freelancers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
