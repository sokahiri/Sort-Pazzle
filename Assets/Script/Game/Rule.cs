using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Rule
{
    public static bool canMoveBall(Pole fromPole, Pole toPole)
    {
        return CanPass(fromPole) && CanRecieve(toPole, fromPole);
    }

    public static bool CanPass(Pole pole)
    {
        if (pole.IsEmpty()) return false;
        

        return true;
    }

    public static bool CanRecieve(Pole pole, Pole fromPole)
    {
        if (pole.IsFull()) return false;


        if (pole.IsEmpty()) return true;
        bool isSameType = fromPole.GetTopBall().Type == pole.GetTopBall().Type;
        return isSameType;
    }

    public static bool IsGameWin(Poles poles)
    {
        return poles.IsAllSorted();
    }

}
