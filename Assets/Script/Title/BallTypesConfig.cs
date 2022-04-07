using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTypesConfig : UpDownButton
{
    override public void UpdateConfig()
    {
        Config.BallTypes = value;
    }
}
