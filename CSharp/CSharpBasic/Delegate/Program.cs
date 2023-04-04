using Delegate;
using System.Threading;

Player player = new Player();
PlayerUI playerUI = new PlayerUI(player);


//Game Logic
while (true)
{
    player.Hp -= 1;
    //playerUI.HpText = player.Hp.ToString();

    playerUI.Draw();
    Thread.Sleep(1000);
}