using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SpaceShip
{

    [SerializeField]
    private float initThrust = 2f;
    [SerializeField]
    private float initThrustHeat = 0.01f;
    [SerializeField]
    private float initMaxSpeed = 6f;
    [SerializeField]
    private float initRotation = 120f;
    [SerializeField]
    private float initBrake = 4f;
    [SerializeField]
    private float initBrakeHeat = 0.02f;
    [SerializeField]
    private float initHealth = 100f;
    [SerializeField]
    private float initShield = 100f;
    [SerializeField]
    private float initHeat = 100f;

    protected override void Start()
    {
        thrust.BaseStat = initThrust;
        thrustHeat.BaseStat = initThrustHeat;
        maxSpeed.BaseStat = initMaxSpeed;
        rotation.BaseStat = initRotation;
        brake.BaseStat = initBrake;
        brakeHeat.BaseStat = initBrakeHeat;
        health.InitializePointStat(initHealth, initHealth);
        shield.InitializePointStat(initShield, initShield);
        heat.InitializePointStat(0f, initHeat);


        base.Start();
    }

    protected override void Update()
    {

        rotateToTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        GetPlayerInput();

        base.Update();

    }

    private void GetPlayerInput()
    {

        thrust.TotalMultiplier = Input.GetAxis("Thrust");
        brake.TotalMultiplier = Input.GetAxis("Brake");


        /*Debug and Tutorial Purpose.
         * Left Click = increase heat by 15, reset to 0 when at max heat.
         * Right Click = take damage by 15 starting with shield and then health when shield is 0,
         * reset to full shield and health when at 0 health.
         * 
        if (Input.GetButtonDown("BasicAttack"))
        {
            heat.CurrentValue += 15;

            if (heat.IsValueMax)
            {
                Debug.Log("Player at Max Heat. Resetting Heat.");
                heat.CurrentValue = 0;
            }

            Debug.Log("Current Heat: " + heat.CurrentValue + "/ Max Heat: " + heat.MaxValue.EffectiveStat);
        }

        if (Input.GetButtonDown("MovementSkill"))
        {
            if (shield.IsValueZero)
            {
                health.CurrentValue -= 15;

                if (health.IsValueZero)
                {
                    Debug.Log("Player at 0 Health. Resurrecting Player with Max Shield.");
                    health.InitializePointStat(initHealth, initHealth);
                    shield.InitializePointStat(initShield, initShield);
                }
            }
            else
            {
                shield.CurrentValue -= 15;

                if (shield.IsValueZero)
                {
                    Debug.Log("Player at 0 Shield. Taking Health Damage.");
                    health.CurrentValue -= shield.UnderflowValue;
                }
            }
            Debug.Log("Current Shield: " + shield.CurrentValue + "/ Max Shield: " + shield.MaxValue.EffectiveStat + "     Current Health: " + health.CurrentValue + "/ Max Health: " + health.MaxValue.EffectiveStat);
        }
        */


    }

}
