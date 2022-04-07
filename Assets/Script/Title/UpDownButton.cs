using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

abstract public class UpDownButton : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private Config config;
    [SerializeField] public byte value;
    [SerializeField] private byte max;
    [SerializeField] private byte min;

    //public UpDownButton(byte value, byte max, byte min)
    //{
    //    this.value = value;
    //    this.max = max;
    //    this.min = min;
    //}

    public void Up()
    {
        if (value == max) return;
        value++;
        UpdateValue();
        UpdateConfig();
    }

    public void Down()
    {
        if (value == min) return;
        value--;
        UpdateValue();
        UpdateConfig();
    }

    abstract public void UpdateConfig();

    public void UpdateValue()
    {
        text.text = value.ToString();
    }

    private void Start()
    {
        UpdateValue();
        UpdateConfig();
    }

}
