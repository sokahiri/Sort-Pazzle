using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Pole : MonoBehaviour
{
    public static readonly byte capacity = 4;

    [SerializeField] private Poles poles;
    [SerializeField] private Slot[] slots;
    [SerializeField] private BallEntrance ballEntrance;

    public byte Count { get; private set; } = 0;
    public bool Disabled { get; private set; } = false;

    public void Pass(Pole pole)
    {
        pole.Recieve(this.RemoveTopBall());
        Disabled = false;
    }

    public void Recieve(Ball ball)
    {
        if (IsFull())
        {
            Debug.LogError("‚±‚êˆÈãŠi”[‚Å‚«‚È‚¢Š‚Éƒ{[ƒ‹‚ğŠi”[‚µ‚æ‚¤‚Æ‚µ‚Ä‚¢‚Ü‚·");
            return;
        }
        Count++;
        Slot slot = slots[Count - 1];
        if (!slot.HasBall())
        {
            Debug.LogError("count’l‚Æ®‡«‚ªæ‚ê‚Ä‚¢‚Ü‚¹‚ñ");
            return;
        }


        slot.Ball = ball;
        ball.transform.parent = slot.transform;
    }

    public Ball GetTopBall()
    {
        if (IsEmpty())
        {
            Debug.LogError("‹ó—v‘f‚ğŠ“¾‚µ‚æ‚¤‚Æ‚µ‚Ä‚¢‚Ü‚·");
            return null;
        }
        return slots[Count - 1].Ball;
    }

    public Ball RemoveTopBall()
    {
        if (IsEmpty())
        {
            Debug.LogError("‹ó—v‘f‚ğíœ‚µ‚æ‚¤‚Æ‚µ‚Ä‚¢‚Ü‚·");
            return null;
        }
        Ball returnBall = slots[Count - 1].RemoveBall();
        Count--;
        return returnBall;
    }

    public bool IsEmpty()
    {
        return Count == 0;
    }

    public bool IsFull()
    {
        return Count == capacity;
    }

    public bool CheckIsSorted()
    {
        if (IsEmpty()) return true;
        if (!IsFull())
        {
            Disabled = false;
            return false;
        }
        for (int i = 0; i < capacity - 1; i++)
        {
            if (slots[i].Ball.Type != slots[i + 1].Ball.Type)
            {
                Disabled = false;
                return false;
            }
        }
        Disabled = true;
        return true;
    }

    public void UpBall()
    {
        GetTopBall().transform.position = ballEntrance.transform.position;
    }

    public void DownBall()
    {
        GetTopBall().transform.position = slots[Count - 1].transform.position;
    }

    private void Start()
    {
    }

    private void OnMouseDown()
    {
        if (Disabled) return;
        poles.Pole_OnClick(this);
    }

    public void SetPoles(Poles poles)
    {
        this.poles = poles;
    }
}
