using System;

namespace StackImplementation_November.Models.BlackJack;

public class Dealer(string name) : Player(name)
{
    public static int StandAt => 15;
}
