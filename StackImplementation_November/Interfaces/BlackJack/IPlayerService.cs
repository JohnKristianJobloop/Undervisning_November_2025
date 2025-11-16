using StackImplementation_November.Models.BlackJack;

namespace StackImplementation_November.Interfaces.BlackJack;


public interface IPlayerService
{

    Player Hit(this Player player, IBlackJackService service);

    Player Stand(this Player player);

    Player DoubleDown(this Player player);

    Player CheckIfBust(this Player player);

    int GetHandScore(this Player player);


}