using Delegate;
using System.Threading;

Player player = new Player();
PlayerUI playerUI = new PlayerUI(player);


//Game Logic
while (true)
{
    player.Hp -= 1;
    //playerUI.HpText = player.Hp.ToString();
    //player.OnHPChanged?.Invoke(1); //event를 걸어놔 외부에서 호출할수 없다
    playerUI.Draw();
    Thread.Sleep(1000);
}