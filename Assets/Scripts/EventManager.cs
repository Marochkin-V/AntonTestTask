using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public static event EventHandler<GameOverEventArgs> GameOverEvent;
    public static event EventHandler<WinEventArgs> WinEvent;
    public static event EventHandler<PlayerDeathEventArgs> PlayerDeathEvent;

    public static void RaiseGameOverEvent(bool isGameOver)
    {
        GameOverEvent?.Invoke(null, new GameOverEventArgs(isGameOver));
    }

    public static void RaiseWinEvent(bool isWin)
    {
        WinEvent?.Invoke(null, new WinEventArgs(isWin));
    }

    public static void RaisePlayerDeathEvent(bool isDead)
    {
        PlayerDeathEvent?.Invoke(null, new PlayerDeathEventArgs(isDead));
    }
}