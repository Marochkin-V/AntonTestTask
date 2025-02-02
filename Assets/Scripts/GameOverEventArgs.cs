using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class GameOverEventArgs : EventArgs
{
    public bool IsGameOver { get; set; }

    public GameOverEventArgs(bool isGameOver)
    {
        IsGameOver = isGameOver;
    }
}
