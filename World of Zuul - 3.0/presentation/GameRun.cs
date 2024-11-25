using World_of_Zuul___3._0.data;

namespace World_of_Zuul___3._0.presentation
{
    class GameRun
    {
        static void Main(string[] args)
        {
            StartScreen.Show();
            GameLogic gameLogic = new GameLogic();
            gameLogic.RunGame();
        }
    }
}
