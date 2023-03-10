using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dexter.Models
{
    public class Pokemon
    {
        public int X2AndX4WeaknessCount
        {
            get
            {
                int count = 0;
                if (against_bug >= 2) count++;
                if (against_dark >= 2) count++;
                if (against_dragon >= 2) count++;
                if (against_electric >= 2) count++;
                if (against_fairy >= 2) count++;
                if (against_fight >= 2) count++;
                if (against_fire >= 2) count++;
                if (against_flying >= 2) count++;
                if (against_ghost >= 2) count++;
                if (against_grass >= 2) count++;
                if (against_ground >= 2) count++;
                if (against_ice >= 2) count++;
                if (against_normal >= 2) count++;
                if (against_poison >= 2) count++;
                if (against_psychic >= 2) count++;
                if (against_rock >= 2) count++;
                if (against_steel >= 2) count++;
                if (against_water >= 2) count++;
                return count;
            }
        }
        public double against_bug { get; set; }
        public double against_dark { get; set; }
        public double against_dragon { get; set; }
        public double against_electric { get; set; }
        public double against_fairy { get; set; }
        public double against_fight { get; set; }
        public double against_fire { get; set; }
        public double against_flying { get; set; }
        public double against_ghost { get; set; }
        public double against_grass { get; set; }
        public double against_ground { get; set; }
        public double against_ice { get; set; }
        public double against_normal { get; set; }
        public double against_poison { get; set; }
        public double against_psychic { get; set; }
        public double against_rock { get; set; }
        public double against_steel { get; set; }
        public double against_water { get; set; }
        [Column("attack")]
        public int Attack { get; set; }
        public int base_egg_steps { get; set; }
        public int base_happiness { get; set; }
        public int base_total { get; set; }
        [Column("capture_rate")]
        public int? CaptureRate { get; set; }
        public string? classfication { get; set; }
        [Column("defense")]
        public int Defense { get; set; }
        public Int32 experience_growth { get; set; }
        public string? height_m { get; set; }
        [Column("hp")]
        public int HP { get; set; }
        public string? japanese_name { get; set; }
        [Column("name")]
        public string Name { get; set; }
        public string? percentage_male { get; set; }
        [Key]
        [Column("pokedex_number")]
        public int PokedexNumber { get; set; }
        [Column("sp_attack")]
        public int SpecialAttack { get; set; }
        [Column("sp_defense")]
        public int SpecialDefense { get; set; }
        [Column("speed")]
        public int Speed { get; set; }
        [Column("type1")]
        public string Type1 { get; set; }
        public string? type2 { get; set; }
        public string TypesString
        {
            get => $"{Type1.ToTitleCase()} {(type2?.Length > 0 ? " and " + type2.ToTitleCase() : "")}";
        }
        public string? weight_kg { get; set; }
        public int? generation { get; set; }
        public int is_legendary { get; set; }
        public string ImagePath => this.PokedexNumber > 801 ? "" : $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{PokedexNumber}.png";

        // Since this is a simple model mapping, doing it manually vs using a library like AutoMapper
        public static Pokemon FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            Pokemon newPokemon = new Pokemon();
            newPokemon.against_bug = Convert.ToDouble(values[1]);
            newPokemon.against_dark = Convert.ToDouble(values[2]);
            newPokemon.against_dragon = Convert.ToDouble(values[3]);
            newPokemon.against_electric = Convert.ToDouble(values[4]);
            newPokemon.against_fairy = Convert.ToDouble(values[5]);
            newPokemon.against_fight = Convert.ToDouble(values[6]);
            newPokemon.against_fire = Convert.ToDouble(values[7]);
            newPokemon.against_flying = Convert.ToDouble(values[8]);
            newPokemon.against_ghost = Convert.ToDouble(values[9]);
            newPokemon.against_grass = Convert.ToDouble(values[10]);
            newPokemon.against_ground = Convert.ToDouble(values[11]);
            newPokemon.against_ice = Convert.ToDouble(values[12]);
            newPokemon.against_normal = Convert.ToDouble(values[13]);
            newPokemon.against_poison = Convert.ToDouble(values[14]);
            newPokemon.against_psychic = Convert.ToDouble(values[15]);
            newPokemon.against_rock = Convert.ToDouble(values[16]);
            newPokemon.against_steel = Convert.ToDouble(values[17]);
            newPokemon.against_water = Convert.ToDouble(values[18]);
            newPokemon.Attack = Convert.ToInt16(values[19]);
            newPokemon.base_egg_steps = Convert.ToInt16(values[20]);
            newPokemon.base_happiness = Convert.ToInt16(values[21]);
            newPokemon.base_total = Convert.ToInt16(values[22]);
            newPokemon.CaptureRate = !String.IsNullOrEmpty(values[23]) ? Convert.ToInt32(values[23]) : null;
            newPokemon.classfication = Convert.ToString(values[24]);
            newPokemon.Defense = Convert.ToInt16(values[25]);
            newPokemon.experience_growth = Convert.ToInt32(values[26]);
            newPokemon.height_m = Convert.ToString(values[27]);
            newPokemon.HP = Convert.ToInt16(values[28]);
            newPokemon.japanese_name = Convert.ToString(values[29]);
            newPokemon.Name = Convert.ToString(values[30]);
            newPokemon.percentage_male = Convert.ToString(values[31]);
            newPokemon.PokedexNumber = Convert.ToInt16(values[32]);
            newPokemon.SpecialAttack = Convert.ToInt16(values[33]);
            newPokemon.SpecialDefense = Convert.ToInt16(values[34]);
            newPokemon.Speed = Convert.ToInt16(values[35]);
            newPokemon.Type1 = Convert.ToString(values[36]);
            newPokemon.type2 = Convert.ToString(values[37]);
            newPokemon.weight_kg = Convert.ToString(values[38]);
            newPokemon.generation = Convert.ToInt16(values[39]);
            newPokemon.is_legendary = Convert.ToInt16(values[40]);
            return newPokemon;
        }
    }
}
