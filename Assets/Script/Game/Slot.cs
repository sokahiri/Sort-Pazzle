using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public Ball Ball { get; set; }

    public bool HasBall()
    {
        return Ball == null;
    }

    public Ball RemoveBall()
    {
        Ball ball = this.Ball;
        Ball = null;
        return ball;
    }

}
