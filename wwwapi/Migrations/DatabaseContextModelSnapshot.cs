﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using wwwapi.Data;

#nullable disable

namespace wwwapi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("wwwapi.Models.AbilityScoreProf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CharacterId")
                        .HasColumnType("integer")
                        .HasColumnName("character_id");

                    b.Property<bool>("Charisma")
                        .HasColumnType("boolean")
                        .HasColumnName("charisma");

                    b.Property<bool>("Constitution")
                        .HasColumnType("boolean")
                        .HasColumnName("constitution");

                    b.Property<bool>("Dexterity")
                        .HasColumnType("boolean")
                        .HasColumnName("dexterity");

                    b.Property<bool>("Intelligence")
                        .HasColumnType("boolean")
                        .HasColumnName("intelligence");

                    b.Property<bool>("Strength")
                        .HasColumnType("boolean")
                        .HasColumnName("strength");

                    b.Property<bool>("Wisdom")
                        .HasColumnType("boolean")
                        .HasColumnName("wisdom");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId")
                        .IsUnique();

                    b.ToTable("AbilityScoreProf");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CharacterId = 2,
                            Charisma = false,
                            Constitution = false,
                            Dexterity = false,
                            Intelligence = false,
                            Strength = false,
                            Wisdom = true
                        },
                        new
                        {
                            Id = 2,
                            CharacterId = 1,
                            Charisma = false,
                            Constitution = true,
                            Dexterity = false,
                            Intelligence = false,
                            Strength = false,
                            Wisdom = false
                        });
                });

            modelBuilder.Entity("wwwapi.Models.AbilityScores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CharacterId")
                        .HasColumnType("integer")
                        .HasColumnName("character_id");

                    b.Property<int>("Charisma")
                        .HasColumnType("integer")
                        .HasColumnName("charisma");

                    b.Property<int>("Constitution")
                        .HasColumnType("integer")
                        .HasColumnName("constitution");

                    b.Property<int>("Dexterity")
                        .HasColumnType("integer")
                        .HasColumnName("dexterity");

                    b.Property<int>("Intelligence")
                        .HasColumnType("integer")
                        .HasColumnName("intelligence");

                    b.Property<int>("Strength")
                        .HasColumnType("integer")
                        .HasColumnName("strength");

                    b.Property<int>("Wisdom")
                        .HasColumnType("integer")
                        .HasColumnName("wisdom");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId")
                        .IsUnique();

                    b.ToTable("ability_scores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CharacterId = 1,
                            Charisma = 6,
                            Constitution = 3,
                            Dexterity = 2,
                            Intelligence = 4,
                            Strength = 1,
                            Wisdom = 5
                        },
                        new
                        {
                            Id = 2,
                            CharacterId = 2,
                            Charisma = 6,
                            Constitution = 5,
                            Dexterity = 2,
                            Intelligence = 4,
                            Strength = 6,
                            Wisdom = 5
                        });
                });

            modelBuilder.Entity("wwwapi.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("characters");

                    b.HasData(
                        new
                        {
                            Id = 1
                        },
                        new
                        {
                            Id = 2
                        });
                });

            modelBuilder.Entity("wwwapi.Models.SkillsExp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("AnimalHandling")
                        .HasColumnType("boolean")
                        .HasColumnName("animal_handling");

                    b.Property<bool>("Arcana")
                        .HasColumnType("boolean")
                        .HasColumnName("arcana");

                    b.Property<bool>("Athletics")
                        .HasColumnType("boolean")
                        .HasColumnName("athletics");

                    b.Property<int>("CharacterId")
                        .HasColumnType("integer")
                        .HasColumnName("character_id");

                    b.Property<bool>("Deception")
                        .HasColumnType("boolean")
                        .HasColumnName("deception");

                    b.Property<bool>("History")
                        .HasColumnType("boolean")
                        .HasColumnName("history");

                    b.Property<bool>("Insight")
                        .HasColumnType("boolean")
                        .HasColumnName("insight");

                    b.Property<bool>("Intimidation")
                        .HasColumnType("boolean")
                        .HasColumnName("intimidation");

                    b.Property<bool>("Investigation")
                        .HasColumnType("boolean")
                        .HasColumnName("investigation");

                    b.Property<bool>("Medicine")
                        .HasColumnType("boolean")
                        .HasColumnName("medicine");

                    b.Property<bool>("Nature")
                        .HasColumnType("boolean")
                        .HasColumnName("nature");

                    b.Property<bool>("Perception")
                        .HasColumnType("boolean")
                        .HasColumnName("perception");

                    b.Property<bool>("Persuation")
                        .HasColumnType("boolean")
                        .HasColumnName("persuation");

                    b.Property<bool>("Religion")
                        .HasColumnType("boolean")
                        .HasColumnName("religion");

                    b.Property<bool>("SleightOfHand")
                        .HasColumnType("boolean")
                        .HasColumnName("sleight_of_hand");

                    b.Property<bool>("Stealth")
                        .HasColumnType("boolean")
                        .HasColumnName("stealth");

                    b.Property<bool>("Survival")
                        .HasColumnType("boolean")
                        .HasColumnName("survival");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId")
                        .IsUnique();

                    b.ToTable("skills_exp");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnimalHandling = false,
                            Arcana = false,
                            Athletics = true,
                            CharacterId = 2,
                            Deception = false,
                            History = false,
                            Insight = false,
                            Intimidation = true,
                            Investigation = false,
                            Medicine = false,
                            Nature = false,
                            Perception = false,
                            Persuation = false,
                            Religion = true,
                            SleightOfHand = false,
                            Stealth = false,
                            Survival = false
                        },
                        new
                        {
                            Id = 2,
                            AnimalHandling = false,
                            Arcana = false,
                            Athletics = false,
                            CharacterId = 1,
                            Deception = false,
                            History = true,
                            Insight = false,
                            Intimidation = false,
                            Investigation = false,
                            Medicine = true,
                            Nature = false,
                            Perception = false,
                            Persuation = false,
                            Religion = true,
                            SleightOfHand = false,
                            Stealth = false,
                            Survival = false
                        });
                });

            modelBuilder.Entity("wwwapi.Models.SkillsProf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("AnimalHandling")
                        .HasColumnType("boolean")
                        .HasColumnName("animal_handling");

                    b.Property<bool>("Arcana")
                        .HasColumnType("boolean")
                        .HasColumnName("arcana");

                    b.Property<bool>("Athletics")
                        .HasColumnType("boolean")
                        .HasColumnName("athletics");

                    b.Property<int>("CharacterId")
                        .HasColumnType("integer")
                        .HasColumnName("character_id");

                    b.Property<bool>("Deception")
                        .HasColumnType("boolean")
                        .HasColumnName("deception");

                    b.Property<bool>("History")
                        .HasColumnType("boolean")
                        .HasColumnName("history");

                    b.Property<bool>("Insight")
                        .HasColumnType("boolean")
                        .HasColumnName("insight");

                    b.Property<bool>("Intimidation")
                        .HasColumnType("boolean")
                        .HasColumnName("intimidation");

                    b.Property<bool>("Investigation")
                        .HasColumnType("boolean")
                        .HasColumnName("investigation");

                    b.Property<bool>("Medicine")
                        .HasColumnType("boolean")
                        .HasColumnName("medicine");

                    b.Property<bool>("Nature")
                        .HasColumnType("boolean")
                        .HasColumnName("nature");

                    b.Property<bool>("Perception")
                        .HasColumnType("boolean")
                        .HasColumnName("perception");

                    b.Property<bool>("Persuation")
                        .HasColumnType("boolean")
                        .HasColumnName("persuation");

                    b.Property<bool>("Religion")
                        .HasColumnType("boolean")
                        .HasColumnName("religion");

                    b.Property<bool>("SleightOfHand")
                        .HasColumnType("boolean")
                        .HasColumnName("sleight_of_hand");

                    b.Property<bool>("Stealth")
                        .HasColumnType("boolean")
                        .HasColumnName("stealth");

                    b.Property<bool>("Survival")
                        .HasColumnType("boolean")
                        .HasColumnName("survival");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId")
                        .IsUnique();

                    b.ToTable("skills_prof");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnimalHandling = false,
                            Arcana = false,
                            Athletics = true,
                            CharacterId = 2,
                            Deception = false,
                            History = false,
                            Insight = false,
                            Intimidation = false,
                            Investigation = false,
                            Medicine = false,
                            Nature = false,
                            Perception = false,
                            Persuation = false,
                            Religion = true,
                            SleightOfHand = true,
                            Stealth = false,
                            Survival = false
                        },
                        new
                        {
                            Id = 2,
                            AnimalHandling = false,
                            Arcana = false,
                            Athletics = false,
                            CharacterId = 1,
                            Deception = false,
                            History = false,
                            Insight = false,
                            Intimidation = true,
                            Investigation = false,
                            Medicine = true,
                            Nature = false,
                            Perception = false,
                            Persuation = false,
                            Religion = true,
                            SleightOfHand = false,
                            Stealth = false,
                            Survival = false
                        });
                });

            modelBuilder.Entity("wwwapi.Models.Speed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CharacterId")
                        .HasColumnType("integer")
                        .HasColumnName("character_id");

                    b.Property<int>("Value")
                        .HasColumnType("integer")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId")
                        .IsUnique();

                    b.ToTable("speed");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CharacterId = 1,
                            Value = 30
                        },
                        new
                        {
                            Id = 2,
                            CharacterId = 2,
                            Value = 35
                        });
                });

            modelBuilder.Entity("wwwapi.Models.Style", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer")
                        .HasColumnName("age");

                    b.Property<int>("Alignment")
                        .HasColumnType("integer")
                        .HasColumnName("alignment");

                    b.Property<int>("Background")
                        .HasColumnType("integer")
                        .HasColumnName("background");

                    b.Property<int>("CharacterId")
                        .HasColumnType("integer")
                        .HasColumnName("character_id");

                    b.Property<int>("Class_")
                        .HasColumnType("integer")
                        .HasColumnName("class");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Eyes")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("eyes");

                    b.Property<string>("Hair")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("hair");

                    b.Property<string>("Height")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("height");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Race")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("race");

                    b.Property<string>("Skin")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("skin");

                    b.Property<string>("Width")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("width");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId")
                        .IsUnique();

                    b.ToTable("styles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 21,
                            Alignment = 4,
                            Background = 2,
                            CharacterId = 1,
                            Class_ = 11,
                            Description = "Description",
                            Eyes = "Blue",
                            Hair = "Not blue",
                            Height = "2'11",
                            Name = "Name",
                            Race = "No",
                            Skin = "Blue",
                            Width = "2'6"
                        },
                        new
                        {
                            Id = 2,
                            Age = 22,
                            Alignment = 6,
                            Background = 1,
                            CharacterId = 2,
                            Class_ = 6,
                            Description = "Other Description",
                            Eyes = "Other Blue",
                            Hair = "Other Not blue",
                            Height = "4'11",
                            Name = "Other Name",
                            Race = "Other No",
                            Skin = "Other Blue",
                            Width = "1'6"
                        });
                });

            modelBuilder.Entity("wwwapi.Models.AbilityScoreProf", b =>
                {
                    b.HasOne("wwwapi.Models.Character", null)
                        .WithOne("ScoreProf")
                        .HasForeignKey("wwwapi.Models.AbilityScoreProf", "CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("wwwapi.Models.AbilityScores", b =>
                {
                    b.HasOne("wwwapi.Models.Character", null)
                        .WithOne("Score")
                        .HasForeignKey("wwwapi.Models.AbilityScores", "CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("wwwapi.Models.SkillsExp", b =>
                {
                    b.HasOne("wwwapi.Models.Character", null)
                        .WithOne("SkillsExp")
                        .HasForeignKey("wwwapi.Models.SkillsExp", "CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("wwwapi.Models.SkillsProf", b =>
                {
                    b.HasOne("wwwapi.Models.Character", null)
                        .WithOne("SkillsProf")
                        .HasForeignKey("wwwapi.Models.SkillsProf", "CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("wwwapi.Models.Speed", b =>
                {
                    b.HasOne("wwwapi.Models.Character", null)
                        .WithOne("Speed")
                        .HasForeignKey("wwwapi.Models.Speed", "CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("wwwapi.Models.Style", b =>
                {
                    b.HasOne("wwwapi.Models.Character", null)
                        .WithOne("Style")
                        .HasForeignKey("wwwapi.Models.Style", "CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("wwwapi.Models.Character", b =>
                {
                    b.Navigation("Score")
                        .IsRequired();

                    b.Navigation("ScoreProf")
                        .IsRequired();

                    b.Navigation("SkillsExp")
                        .IsRequired();

                    b.Navigation("SkillsProf")
                        .IsRequired();

                    b.Navigation("Speed")
                        .IsRequired();

                    b.Navigation("Style")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
