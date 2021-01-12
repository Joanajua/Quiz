using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiz1.Migrations
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02174cf0–9412–4cfe-afbf-59f706d72cf6", "12ef6f7b-6cee-44c1-89ff-2a70878402b2", "Admin", "ADMIN" },
                    { "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "378cb095-0d65-4898-b772-365a99f30be2", "RO-User", "RO-USER" },
                    { "341743f0-asd2–42de-atsy-59kmkkmk72cf6", "03c2bb27-9703-42ba-801b-0dbb3f2048ec", "PO-User", "PO-USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-atsy-59kmkkmk72cf6");
        }
    }
}
