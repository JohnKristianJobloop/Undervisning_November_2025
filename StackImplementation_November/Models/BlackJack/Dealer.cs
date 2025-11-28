using System;

namespace StackImplementation_November.Models.BlackJack;

public class Dealer(string name) : Player(name)
{
    /// <summary>
    /// The value of hand at which the dealer should stand automatically.
    /// </summary>
    public int StandAt => 15;
}
