using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyPoleConfig : UpDownButton
{
    override public void UpdateConfig()
    {
        Config.EmptyPoles = value;
    }
}
