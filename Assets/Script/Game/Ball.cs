using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private string _type;
    public string Type
    {
        get
        {
            return _type;
        }
    }
}
