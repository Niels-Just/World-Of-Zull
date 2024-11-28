using World_Of_Zull_4._0.domain;
using World_Of_Zull_4._0.presentation;

namespace World_Of_Zull_4._0.data
{
    namespace World_Of_Zull_4._0.presentation
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
}


