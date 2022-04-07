using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    public Pole FromPole { get; private set; }
    public Pole ToPole { get; private set; } 

    public Move(Pole fromPole, Pole toPole)
    {
        FromPole = fromPole;
        ToPole = toPole;
    }
}

public class MoveHistory
{
    private LinkedList<Move> moves = new LinkedList<Move>();
    private Poles poles;

    public MoveHistory(Poles poles)
    {
        this.poles = poles;
    }

    public int Count
    {
        get { return moves.Count; }
    }

    public void Add(Pole fromPole, Pole toPole)
    {
        moves.AddLast(new Move(fromPole, toPole));
    }

    public void Undo()
    {
        if (moves.Count == 0) return;
        Move lastMove = moves.Last.Value;
        poles.MoveBall(lastMove.ToPole, lastMove.FromPole);
        moves.RemoveLast();
    }

    public void Reset()
    {
        while (moves.Count != 0)
        {
            Undo();
        }
    }

    public Move peek()
    {
        return moves.Last.Value;
    }
}