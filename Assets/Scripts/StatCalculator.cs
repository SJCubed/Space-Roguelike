using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatCalculator
{

    private float baseStat;
    private float baseAdditive;
    private float baseMultiplier;
    private float totalAdditive;
    private float totalMultiplier;
    private float effectiveStat;

    public float BaseStat
    {
        get
        {
            return baseStat;
        }
        set
        {
            baseStat = value;
            CalculateEffectiveStat();
        }
    }

    public float BaseAdditive
    {
        get
        {
            return baseAdditive;
        }
        set
        {
            baseAdditive = value;
            CalculateEffectiveStat();
        }
    }

    public float BaseMultiplier
    {
        get
        {
            return baseMultiplier;
        }
        set
        {
            baseMultiplier = value;
            CalculateEffectiveStat();
        }
    }

    public float TotalAdditive
    {
        get
        {
            return totalAdditive;
        }
        set
        {
            totalAdditive = value;
            CalculateEffectiveStat();
        }
    }

    public float TotalMultiplier
    {
        get
        {
            return totalMultiplier;
        }
        set
        {
            totalMultiplier = value;
            CalculateEffectiveStat();
        }
    }
    
    public float EffectiveStat
    {
        get
        {
            return CalculateEffectiveStat();
        }
    }

    public float CalculateEffectiveStat()
    {
        return effectiveStat = (((baseStat + baseAdditive) * baseMultiplier) + totalAdditive) * totalMultiplier;
    }


    //Constructor with all values set
    public StatCalculator (float base_stat, float base_additive, float base_multiplier, float total_additive, float total_multiplier)
    {
        baseStat = base_stat;
        baseAdditive = base_additive;
        baseMultiplier = base_multiplier;
        totalAdditive = total_additive;
        totalMultiplier = total_multiplier;
        CalculateEffectiveStat();
    }


    //Default Constructor
    public StatCalculator()
    {
        baseStat = 1f;
        baseAdditive = 0f;
        baseMultiplier = 1f;
        totalAdditive = 0f;
        totalMultiplier = 1f;
        CalculateEffectiveStat();
    }

}
