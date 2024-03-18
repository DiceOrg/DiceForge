using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ability",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    value = table.Column<int>(type: "integer", nullable: false),
                    prof = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ability", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "characters",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_characters", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "skill",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    prof = table.Column<bool>(type: "boolean", nullable: false),
                    exp = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skill", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "abilities",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    strength_id = table.Column<int>(type: "integer", nullable: false),
                    dexterity_id = table.Column<int>(type: "integer", nullable: false),
                    constitution_id = table.Column<int>(type: "integer", nullable: false),
                    intelligence_id = table.Column<int>(type: "integer", nullable: false),
                    wisdom_id = table.Column<int>(type: "integer", nullable: false),
                    charisma_id = table.Column<int>(type: "integer", nullable: false),
                    character_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abilities", x => x.id);
                    table.ForeignKey(
                        name: "FK_abilities_ability_charisma_id",
                        column: x => x.charisma_id,
                        principalTable: "ability",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_abilities_ability_constitution_id",
                        column: x => x.constitution_id,
                        principalTable: "ability",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_abilities_ability_dexterity_id",
                        column: x => x.dexterity_id,
                        principalTable: "ability",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_abilities_ability_intelligence_id",
                        column: x => x.intelligence_id,
                        principalTable: "ability",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_abilities_ability_strength_id",
                        column: x => x.strength_id,
                        principalTable: "ability",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_abilities_ability_wisdom_id",
                        column: x => x.wisdom_id,
                        principalTable: "ability",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_abilities_characters_character_id",
                        column: x => x.character_id,
                        principalTable: "characters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "speed",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    value = table.Column<int>(type: "integer", nullable: false),
                    character_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_speed", x => x.id);
                    table.ForeignKey(
                        name: "FK_speed_characters_character_id",
                        column: x => x.character_id,
                        principalTable: "characters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "styles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    age = table.Column<int>(type: "integer", nullable: false),
                    height = table.Column<string>(type: "text", nullable: false),
                    width = table.Column<string>(type: "text", nullable: false),
                    eyes = table.Column<string>(type: "text", nullable: false),
                    hair = table.Column<string>(type: "text", nullable: false),
                    skin = table.Column<string>(type: "text", nullable: false),
                    race = table.Column<string>(type: "text", nullable: false),
                    @class = table.Column<int>(name: "class", type: "integer", nullable: false),
                    alignment = table.Column<int>(type: "integer", nullable: false),
                    background = table.Column<int>(type: "integer", nullable: false),
                    character_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_styles", x => x.id);
                    table.ForeignKey(
                        name: "FK_styles_characters_character_id",
                        column: x => x.character_id,
                        principalTable: "characters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "skills",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    acrobatics_id = table.Column<int>(type: "integer", nullable: false),
                    animal_handling_id = table.Column<int>(type: "integer", nullable: false),
                    arcana_id = table.Column<int>(type: "integer", nullable: false),
                    athletics_id = table.Column<int>(type: "integer", nullable: false),
                    deceptionid = table.Column<int>(name: "deception:id", type: "integer", nullable: false),
                    history_id = table.Column<int>(type: "integer", nullable: false),
                    insight_id = table.Column<int>(type: "integer", nullable: false),
                    intimidation_id = table.Column<int>(type: "integer", nullable: false),
                    investigation_id = table.Column<int>(type: "integer", nullable: false),
                    medicine_id = table.Column<int>(type: "integer", nullable: false),
                    nature_id = table.Column<int>(type: "integer", nullable: false),
                    perception_id = table.Column<int>(type: "integer", nullable: false),
                    performance_id = table.Column<int>(type: "integer", nullable: false),
                    persuation_id = table.Column<int>(type: "integer", nullable: false),
                    religion_id = table.Column<int>(type: "integer", nullable: false),
                    sleight_of_hand_id = table.Column<int>(type: "integer", nullable: false),
                    stealth_id = table.Column<int>(type: "integer", nullable: false),
                    survival_id = table.Column<int>(type: "integer", nullable: false),
                    character_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skills", x => x.id);
                    table.ForeignKey(
                        name: "FK_skills_characters_character_id",
                        column: x => x.character_id,
                        principalTable: "characters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_skills_skill_acrobatics_id",
                        column: x => x.acrobatics_id,
                        principalTable: "skill",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_skills_skill_animal_handling_id",
                        column: x => x.animal_handling_id,
                        principalTable: "skill",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_skills_skill_arcana_id",
                        column: x => x.arcana_id,
                        principalTable: "skill",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_skills_skill_athletics_id",
                        column: x => x.athletics_id,
                        principalTable: "skill",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_skills_skill_deception:id",
                        column: x => x.deceptionid,
                        principalTable: "skill",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_skills_skill_history_id",
                        column: x => x.history_id,
                        principalTable: "skill",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_skills_skill_insight_id",
                        column: x => x.insight_id,
                        principalTable: "skill",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_skills_skill_intimidation_id",
                        column: x => x.intimidation_id,
                        principalTable: "skill",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_skills_skill_investigation_id",
                        column: x => x.investigation_id,
                        principalTable: "skill",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_skills_skill_medicine_id",
                        column: x => x.medicine_id,
                        principalTable: "skill",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_skills_skill_nature_id",
                        column: x => x.nature_id,
                        principalTable: "skill",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_skills_skill_perception_id",
                        column: x => x.perception_id,
                        principalTable: "skill",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_skills_skill_performance_id",
                        column: x => x.performance_id,
                        principalTable: "skill",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_skills_skill_persuation_id",
                        column: x => x.persuation_id,
                        principalTable: "skill",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_skills_skill_religion_id",
                        column: x => x.religion_id,
                        principalTable: "skill",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_skills_skill_sleight_of_hand_id",
                        column: x => x.sleight_of_hand_id,
                        principalTable: "skill",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_skills_skill_stealth_id",
                        column: x => x.stealth_id,
                        principalTable: "skill",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_skills_skill_survival_id",
                        column: x => x.survival_id,
                        principalTable: "skill",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ability",
                columns: new[] { "id", "prof", "value" },
                values: new object[,]
                {
                    { 1, false, 1 },
                    { 2, true, 2 },
                    { 3, false, 3 },
                    { 4, true, 4 },
                    { 5, false, 5 },
                    { 6, true, 6 },
                    { 7, false, 7 },
                    { 8, true, 8 },
                    { 9, false, 9 },
                    { 10, true, 10 },
                    { 11, false, 11 },
                    { 12, true, 12 }
                });

            migrationBuilder.InsertData(
                table: "characters",
                column: "id",
                values: new object[]
                {
                    1,
                    2
                });

            migrationBuilder.InsertData(
                table: "skill",
                columns: new[] { "id", "exp", "prof" },
                values: new object[,]
                {
                    { 1, false, false },
                    { 2, false, false },
                    { 3, false, true },
                    { 4, false, false },
                    { 5, true, false },
                    { 6, false, true },
                    { 7, false, false },
                    { 8, false, false },
                    { 9, false, true },
                    { 10, true, false },
                    { 11, false, false },
                    { 12, false, true },
                    { 13, false, false },
                    { 14, false, false },
                    { 15, true, true },
                    { 16, false, false },
                    { 17, false, false },
                    { 18, false, true },
                    { 19, false, false },
                    { 20, true, false },
                    { 21, false, true },
                    { 22, false, false },
                    { 23, false, false },
                    { 24, false, true },
                    { 25, true, false },
                    { 26, false, false },
                    { 27, false, true },
                    { 28, false, false },
                    { 29, false, false },
                    { 30, true, true },
                    { 31, false, false },
                    { 32, false, false },
                    { 33, false, true },
                    { 34, false, false },
                    { 35, true, false },
                    { 36, false, true }
                });

            migrationBuilder.InsertData(
                table: "abilities",
                columns: new[] { "id", "character_id", "charisma_id", "constitution_id", "dexterity_id", "intelligence_id", "strength_id", "wisdom_id" },
                values: new object[,]
                {
                    { 1, 1, 6, 3, 2, 4, 1, 5 },
                    { 2, 2, 12, 9, 8, 10, 7, 11 }
                });

            migrationBuilder.InsertData(
                table: "skills",
                columns: new[] { "id", "acrobatics_id", "animal_handling_id", "arcana_id", "athletics_id", "character_id", "deception:id", "history_id", "insight_id", "intimidation_id", "investigation_id", "medicine_id", "nature_id", "perception_id", "performance_id", "persuation_id", "religion_id", "sleight_of_hand_id", "stealth_id", "survival_id" },
                values: new object[,]
                {
                    { 1, 1, 2, 3, 4, 1, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 },
                    { 2, 19, 20, 21, 22, 2, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36 }
                });

            migrationBuilder.InsertData(
                table: "speed",
                columns: new[] { "id", "character_id", "value" },
                values: new object[,]
                {
                    { 1, 1, 30 },
                    { 2, 2, 35 }
                });

            migrationBuilder.InsertData(
                table: "styles",
                columns: new[] { "id", "age", "alignment", "background", "character_id", "class", "description", "eyes", "hair", "height", "name", "race", "skin", "width" },
                values: new object[,]
                {
                    { 1, 21, 4, 2, 1, 11, "Description", "Blue", "Not blue", "2'11", "Name", "No", "Blue", "2'6" },
                    { 2, 22, 6, 1, 2, 6, "Other Description", "Other Blue", "Other Not blue", "4'11", "Other Name", "Other No", "Other Blue", "1'6" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_abilities_character_id",
                table: "abilities",
                column: "character_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_abilities_charisma_id",
                table: "abilities",
                column: "charisma_id");

            migrationBuilder.CreateIndex(
                name: "IX_abilities_constitution_id",
                table: "abilities",
                column: "constitution_id");

            migrationBuilder.CreateIndex(
                name: "IX_abilities_dexterity_id",
                table: "abilities",
                column: "dexterity_id");

            migrationBuilder.CreateIndex(
                name: "IX_abilities_intelligence_id",
                table: "abilities",
                column: "intelligence_id");

            migrationBuilder.CreateIndex(
                name: "IX_abilities_strength_id",
                table: "abilities",
                column: "strength_id");

            migrationBuilder.CreateIndex(
                name: "IX_abilities_wisdom_id",
                table: "abilities",
                column: "wisdom_id");

            migrationBuilder.CreateIndex(
                name: "IX_skills_acrobatics_id",
                table: "skills",
                column: "acrobatics_id");

            migrationBuilder.CreateIndex(
                name: "IX_skills_animal_handling_id",
                table: "skills",
                column: "animal_handling_id");

            migrationBuilder.CreateIndex(
                name: "IX_skills_arcana_id",
                table: "skills",
                column: "arcana_id");

            migrationBuilder.CreateIndex(
                name: "IX_skills_athletics_id",
                table: "skills",
                column: "athletics_id");

            migrationBuilder.CreateIndex(
                name: "IX_skills_character_id",
                table: "skills",
                column: "character_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_skills_deception:id",
                table: "skills",
                column: "deception:id");

            migrationBuilder.CreateIndex(
                name: "IX_skills_history_id",
                table: "skills",
                column: "history_id");

            migrationBuilder.CreateIndex(
                name: "IX_skills_insight_id",
                table: "skills",
                column: "insight_id");

            migrationBuilder.CreateIndex(
                name: "IX_skills_intimidation_id",
                table: "skills",
                column: "intimidation_id");

            migrationBuilder.CreateIndex(
                name: "IX_skills_investigation_id",
                table: "skills",
                column: "investigation_id");

            migrationBuilder.CreateIndex(
                name: "IX_skills_medicine_id",
                table: "skills",
                column: "medicine_id");

            migrationBuilder.CreateIndex(
                name: "IX_skills_nature_id",
                table: "skills",
                column: "nature_id");

            migrationBuilder.CreateIndex(
                name: "IX_skills_perception_id",
                table: "skills",
                column: "perception_id");

            migrationBuilder.CreateIndex(
                name: "IX_skills_performance_id",
                table: "skills",
                column: "performance_id");

            migrationBuilder.CreateIndex(
                name: "IX_skills_persuation_id",
                table: "skills",
                column: "persuation_id");

            migrationBuilder.CreateIndex(
                name: "IX_skills_religion_id",
                table: "skills",
                column: "religion_id");

            migrationBuilder.CreateIndex(
                name: "IX_skills_sleight_of_hand_id",
                table: "skills",
                column: "sleight_of_hand_id");

            migrationBuilder.CreateIndex(
                name: "IX_skills_stealth_id",
                table: "skills",
                column: "stealth_id");

            migrationBuilder.CreateIndex(
                name: "IX_skills_survival_id",
                table: "skills",
                column: "survival_id");

            migrationBuilder.CreateIndex(
                name: "IX_speed_character_id",
                table: "speed",
                column: "character_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_styles_character_id",
                table: "styles",
                column: "character_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "abilities");

            migrationBuilder.DropTable(
                name: "skills");

            migrationBuilder.DropTable(
                name: "speed");

            migrationBuilder.DropTable(
                name: "styles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ability");

            migrationBuilder.DropTable(
                name: "skill");

            migrationBuilder.DropTable(
                name: "characters");
        }
    }
}
