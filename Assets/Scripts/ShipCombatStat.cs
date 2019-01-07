using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCombatStat
{

    private bool valueAtMax;

    public bool ValueAtMax
    {
        get
        {
            if (currentValue >= maxValue)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }

    private float currentValue;

    public float CurrentValue
    {
        get
        {
            return currentValue;
        }
        set
        {

            if (value < 0)
            {
                currentValue = 0;
            }

            else if (value > maxValue)
            {

                currentValue = maxValue;
            }

            else
            {
                currentValue = value;
            }

        }
    }

    private float maxValue;

    public float MaxValue
    {

        get
        {
            return maxValue;
        }

        set
        {
            maxValue = value;
        }


    }

    public void Initialize(float currentValue, float maxValue)
    {

        CurrentValue = currentValue;
        MaxValue = maxValue;

    }


}
