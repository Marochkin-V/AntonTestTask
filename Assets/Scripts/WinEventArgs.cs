using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class WinEventArgs : EventArgs
{
    public bool IsWin { get; set; }

    public WinEventArgs(bool isWin)
    {
        IsWin = isWin;
    }
}
