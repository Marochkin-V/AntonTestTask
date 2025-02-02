using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class PlayerDeathEventArgs : EventArgs
{
    public bool IsDead { get; set; }

    public PlayerDeathEventArgs(bool isDead)
    {
        IsDead = isDead;
    }
}
