using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dexter.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    pokedexnumber = table.Column<int>(name: "pokedex_number", type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    abilities = table.Column<string>(type: "TEXT", nullable: false),
                    againstbug = table.Column<double>(name: "against_bug", type: "REAL", nullable: false),
                    againstdark = table.Column<double>(name: "against_dark", type: "REAL", nullable: false),
                    againstdragon = table.Column<double>(name: "against_dragon", type: "REAL", nullable: false),
                    againstelectric = table.Column<double>(name: "against_electric", type: "REAL", nullable: false),
                    againstfairy = table.Column<double>(name: "against_fairy", type: "REAL", nullable: false),
                    againstfight = table.Column<double>(name: "against_fight", type: "REAL", nullable: false),
                    againstfire = table.Column<double>(name: "against_fire", type: "REAL", nullable: false),
                    againstflying = table.Column<double>(name: "against_flying", type: "REAL", nullable: false),
                    againstghost = table.Column<double>(name: "against_ghost", type: "REAL", nullable: false),
                    againstgrass = table.Column<double>(name: "against_grass", type: "REAL", nullable: false),
                    againstground = table.Column<double>(name: "against_ground", type: "REAL", nullable: false),
                    againstice = table.Column<double>(name: "against_ice", type: "REAL", nullable: false),
                    againstnormal = table.Column<double>(name: "against_normal", type: "REAL", nullable: false),
                    againstpoison = table.Column<double>(name: "against_poison", type: "REAL", nullable: false),
                    againstpsychic = table.Column<double>(name: "against_psychic", type: "REAL", nullable: false),
                    againstrock = table.Column<double>(name: "against_rock", type: "REAL", nullable: false),
                    againststeel = table.Column<double>(name: "against_steel", type: "REAL", nullable: false),
                    againstwater = table.Column<double>(name: "against_water", type: "REAL", nullable: false),
                    attack = table.Column<int>(type: "INTEGER", nullable: false),
                    baseeggsteps = table.Column<int>(name: "base_egg_steps", type: "INTEGER", nullable: false),
                    basehappiness = table.Column<int>(name: "base_happiness", type: "INTEGER", nullable: false),
                    basetotal = table.Column<int>(name: "base_total", type: "INTEGER", nullable: false),
                    capturerate = table.Column<int>(name: "capture_rate", type: "INTEGER", nullable: false),
                    classfication = table.Column<string>(type: "TEXT", nullable: true),
                    defense = table.Column<int>(type: "INTEGER", nullable: false),
                    experiencegrowth = table.Column<int>(name: "experience_growth", type: "INTEGER", nullable: false),
                    heightm = table.Column<double>(name: "height_m", type: "REAL", nullable: false),
                    hp = table.Column<int>(type: "INTEGER", nullable: false),
                    japanesename = table.Column<string>(name: "japanese_name", type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    percentagemale = table.Column<decimal>(name: "percentage_male", type: "TEXT", nullable: false),
                    spattack = table.Column<int>(name: "sp_attack", type: "INTEGER", nullable: false),
                    spdefense = table.Column<int>(name: "sp_defense", type: "INTEGER", nullable: false),
                    speed = table.Column<int>(type: "INTEGER", nullable: false),
                    type1 = table.Column<string>(type: "TEXT", nullable: false),
                    type2 = table.Column<string>(type: "TEXT", nullable: false),
                    weightkg = table.Column<decimal>(name: "weight_kg", type: "TEXT", nullable: false),
                    generation = table.Column<int>(type: "INTEGER", nullable: false),
                    islegendary = table.Column<int>(name: "is_legendary", type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.pokedexnumber);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");
        }
    }
}
