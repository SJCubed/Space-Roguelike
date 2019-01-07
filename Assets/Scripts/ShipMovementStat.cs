using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovementStat
{

    private float baseValue;

    public float BaseValue
    {
        get
        {
            return baseValue;
        }
        set
        {
            if (value < 0)
            {
                baseValue = 0;
            }
            else
            {
                baseValue = value;
            }

        }
    }

    private float effectiveValue;

    public float EffectiveValue
    {
        get
        {
            return effectiveValue;
        }
        set
        {
            effectiveValue = value;
        }

    }

}
