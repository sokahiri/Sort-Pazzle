using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poles : MonoBehaviour
{
    private Pole[] poles;
    [SerializeField] private Table table;

    private Pole selectedPole;
    public byte countOfSortedPole = 0;

    public bool isDebug = false;
    public void ToggleIsDebug()
    {
        isDebug = true;
    }
    

    private void Start()
    {

    }

    public void Pole_OnClick(Pole pole)
    {
        if (IsAnyPoleSelected())
        {
            if(selectedPole == pole)
            {
                //Debug.Log("Reset SelectedPole");
                selectedPole.DownBall();
                selectedPole = null;
            }
            else
            {
                if ((isDebug&&!pole.IsFull()&&!pole.IsEmpty())||Rule.canMoveBall(selectedPole, pole))
                {
                    MoveBall(selectedPole, pole);
                    table.history.Add(selectedPole, pole);
                    table.UpdateTurnsDisplay();

                    selectedPole = null;

                    if (pole.CheckIsSorted())
                    {
                        countOfSortedPole++;
                        if (Rule.IsGameWin(this))
                        {
                            table.ClearGame();
                        }
                    }
                }
                else
                {
                    //Debug.Log("Update SelectedPole");
                    selectedPole.DownBall();
                    selectedPole = pole;
                    pole.UpBall();
                }
            }
        }
        else
        {
            if (pole.IsEmpty())
            {
                //Debug.Log("Do Nothing");
            }
            else
            {
                //Debug.Log("Set SelectedPole");
                selectedPole = pole;
                pole.UpBall();
            }
            
        }
    }
    public void MoveBall(Pole fromPole, Pole toPole)
    {
        fromPole.Pass(toPole);
        toPole.DownBall();
    }

    public bool IsAnyPoleSelected()
    {
        return selectedPole != null;
    }

    public void DefinePolesSize(byte size)
    {
        poles = new Pole[size];
    }

    public void PushPole(Pole pole)
    {
        for(int i = 0; i < poles.Length; i++)
        {
            if (poles[i] == default)
            {
                poles[i] = pole;
                return;
            }
        }
        return;
    }

    public bool IsAllSorted()
    {
        foreach(var pole in poles)
        {
            if (!pole.CheckIsSorted()) return false;
        }
        return true;
    }
}
