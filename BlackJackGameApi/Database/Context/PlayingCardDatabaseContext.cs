using System;
using Microsoft.EntityFrameworkCore;
using StackImplementation_November.Enums;
using StackImplementation_November.Models.PlayingCard;

namespace BlackJackGameApi.Database.Context;

public class PlayingCardDatabaseContext(DbContextOptions<PlayingCardDatabaseContext> options) : DbContext(options)
{
    public DbSet<CardEntity> Cards {get;set;}
    public DbSet<DeckEntity> Decks {get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        int id = 0;
        var seedData = Enum.GetValues<Suits>().SelectMany(s => 
                                    Enum.GetValues<Value>().Select(v => 
                                                            new CardEntity
                                                            {
                                                                Id = ++id,
                                                                Suit = s,
                                                                Value = v,
                                                                Color = s == Suits.Clubs || s == Suits.Spades ? Color.Black : Color.Red
                                                            }));
        modelBuilder.Entity<CardEntity>().HasMany(c => c.Decks).WithMany(d => d.Cards);
        modelBuilder.Entity<CardEntity>().HasData(
            seedData
        );

    }
}
