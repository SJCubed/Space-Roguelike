using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBasedStat
{

    private bool isValueZero;
    private bool isValueMax;
    private float currentValue;
    private float underflowValue;
    private float overflowValue;
    private StatCalculator maxValue = new StatCalculator();

    public StatCalculator MaxValue { get => maxValue; set => maxValue = value; }

    public float UnderflowValue
    {
        get
        {
            return underflowValue;
        }
    }

    public float OverflowValue
    {
        get
        {
            return overflowValue;
        }
    }


    public float CurrentValue
    {
        get
        {

            return currentValue;

        }
        set
        {

            underflowValue = 0f;
            overflowValue = 0f;

            if (value < 0)
            {
                underflowValue = 0 - value;
                currentValue = 0;
            }
            else if (value > maxValue.EffectiveStat)
            {
                overflowValue = value - maxValue.EffectiveStat;
                currentValue = maxValue.EffectiveStat;
            }
            else
            {
                currentValue = value;
            }

            isValueZero = (currentValue == 0f);
            isValueMax = (currentValue == maxValue.EffectiveStat);

        }
    }

    public bool IsValueZero
    {
        get
        {

            return isValueZero;

        }
    }

    public bool IsValueMax
    {
        get
        {

            return isValueMax;

        }
    }

    public void InitializePointStat(float current_value, float max_value)
    {
        maxValue.BaseStat = max_value;
        CurrentValue = current_value;
    }

}
