using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClearUI : MonoBehaviour
{
    public Table table;

    [SerializeField] private Text clearTime;
    [SerializeField] private Text clearCount;

    // Start is called before the first frame update
    void Start()
    {
        clearTime.text = table.timeDisplay.text;
        clearCount.text = table.Turns.ToString();
    }

    public void ReturnHome()
    {
        table.ReturnHome();
    }
}
