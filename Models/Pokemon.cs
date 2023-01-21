namespace Dexter.Models
{
    public class Pokemon
    {
        public int pokedex_number { get; set; }
        public string[] abilities { get; set; }
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
        public int attack { get; set; }
        public int base_egg_steps { get; set; }
        public int base_happiness { get; set; }
        public int base_total { get; set; }
        public int capture_rate { get; set; }
        public string? classfication { get; set; }
        public int defense { get; set; }
        public int experience_growth { get; set; }
        public double height_m { get; set; }
        public int hp { get; set; }
        public string japanese_name { get; set; }
        public string name { get; set; }
        public decimal percentage_male { get; set; }
        public int sp_attack { get; set; }
        public int sp_defense { get; set; }
        public int speed { get; set; }
        public string type1 { get; set; }
        public string type2 { get; set; }
        public decimal weight_kg { get; set; }
        public int generation { get; set; }
        public int is_legendary { get; set; }
}
}
