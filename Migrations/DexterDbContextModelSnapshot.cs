﻿// <auto-generated />
using System;
using Dexter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Dexter.Migrations
{
    [DbContext(typeof(DexterDbContext))]
    partial class DexterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("Dexter.Models.Pokemon", b =>
                {
                    b.Property<int>("PokedexNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("pokedex_number");

                    b.Property<int>("Attack")
                        .HasColumnType("INTEGER")
                        .HasColumnName("attack");

                    b.Property<int?>("CaptureRate")
                        .HasColumnType("INTEGER")
                        .HasColumnName("capture_rate");

                    b.Property<int>("Defense")
                        .HasColumnType("INTEGER")
                        .HasColumnName("defense");

                    b.Property<int>("HP")
                        .HasColumnType("INTEGER")
                        .HasColumnName("hp");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<int>("SpecialAttack")
                        .HasColumnType("INTEGER")
                        .HasColumnName("sp_attack");

                    b.Property<int>("SpecialDefense")
                        .HasColumnType("INTEGER")
                        .HasColumnName("sp_defense");

                    b.Property<int>("Speed")
                        .HasColumnType("INTEGER")
                        .HasColumnName("speed");

                    b.Property<string>("Type1")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("type1");

                    b.Property<double>("against_bug")
                        .HasColumnType("REAL");

                    b.Property<double>("against_dark")
                        .HasColumnType("REAL");

                    b.Property<double>("against_dragon")
                        .HasColumnType("REAL");

                    b.Property<double>("against_electric")
                        .HasColumnType("REAL");

                    b.Property<double>("against_fairy")
                        .HasColumnType("REAL");

                    b.Property<double>("against_fight")
                        .HasColumnType("REAL");

                    b.Property<double>("against_fire")
                        .HasColumnType("REAL");

                    b.Property<double>("against_flying")
                        .HasColumnType("REAL");

                    b.Property<double>("against_ghost")
                        .HasColumnType("REAL");

                    b.Property<double>("against_grass")
                        .HasColumnType("REAL");

                    b.Property<double>("against_ground")
                        .HasColumnType("REAL");

                    b.Property<double>("against_ice")
                        .HasColumnType("REAL");

                    b.Property<double>("against_normal")
                        .HasColumnType("REAL");

                    b.Property<double>("against_poison")
                        .HasColumnType("REAL");

                    b.Property<double>("against_psychic")
                        .HasColumnType("REAL");

                    b.Property<double>("against_rock")
                        .HasColumnType("REAL");

                    b.Property<double>("against_steel")
                        .HasColumnType("REAL");

                    b.Property<double>("against_water")
                        .HasColumnType("REAL");

                    b.Property<int>("base_egg_steps")
                        .HasColumnType("INTEGER");

                    b.Property<int>("base_happiness")
                        .HasColumnType("INTEGER");

                    b.Property<int>("base_total")
                        .HasColumnType("INTEGER");

                    b.Property<string>("classfication")
                        .HasColumnType("TEXT");

                    b.Property<int>("experience_growth")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("generation")
                        .HasColumnType("INTEGER");

                    b.Property<string>("height_m")
                        .HasColumnType("TEXT");

                    b.Property<int>("is_legendary")
                        .HasColumnType("INTEGER");

                    b.Property<string>("japanese_name")
                        .HasColumnType("TEXT");

                    b.Property<string>("percentage_male")
                        .HasColumnType("TEXT");

                    b.Property<string>("type2")
                        .HasColumnType("TEXT");

                    b.Property<string>("weight_kg")
                        .HasColumnType("TEXT");

                    b.HasKey("PokedexNumber");

                    b.ToTable("Pokemons");
                });
#pragma warning restore 612, 618
        }
    }
}
