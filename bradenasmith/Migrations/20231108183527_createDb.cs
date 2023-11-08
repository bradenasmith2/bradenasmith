using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace bradenasmith.Migrations
{
    /// <inheritdoc />
    public partial class createDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "blog_posts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    topic = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    sec_one_title = table.Column<string>(type: "text", nullable: false),
                    sec_one_content = table.Column<string>(type: "text", nullable: false),
                    sec_two_title = table.Column<string>(type: "text", nullable: false),
                    sec_two_content = table.Column<string>(type: "text", nullable: false),
                    sec_three_title = table.Column<string>(type: "text", nullable: true),
                    sec_three_content = table.Column<string>(type: "text", nullable: true),
                    sec_four_title = table.Column<string>(type: "text", nullable: true),
                    sec_four_content = table.Column<string>(type: "text", nullable: true),
                    sec_five_title = table.Column<string>(type: "text", nullable: true),
                    sec_five_content = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_blog_posts", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "blog_posts");
        }
    }
}
