using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public class Caretaker
    {
        Memento gameState;

        public Caretaker(Memento gameState)
        {
            this.gameState = gameState;
        }

        public Memento GameState
        {
            get
            {
                return gameState;
            }
            set
            {
                gameState = value;
            }
        }
    }
}
