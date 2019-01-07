using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SpaceShip
{

    [SerializeField]
    private float initThrust = 2f;
    [SerializeField]
    private float initMaxSpeed = 6f;
    [SerializeField]
    private float initRotation = 120f;
    [SerializeField]
    private float initBrake = 4f;
    [SerializeField]
    private float initHealth = 100f;
    [SerializeField]
    private float initShield = 100f;
    [SerializeField]
    private float initHeat = 0f;
    [SerializeField]
    private float initMaxHeat = 100f;

    protected override void Start()
    { 
        thrust.BaseValue = initThrust;
        maxSpeed.BaseValue = initMaxSpeed;
        rotation.BaseValue = initRotation;
        brake.BaseValue = initBrake;
        health.Initialize(initHealth, initHealth);
        shield.Initialize(initShield, initShield);
        heat.Initialize(initHeat, initMaxHeat);

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

        thrust.EffectiveValue = Input.GetAxis("Thrust") * thrust.BaseValue;
        maxSpeed.EffectiveValue = maxSpeed.BaseValue;
        rotation.EffectiveValue = rotation.BaseValue;
        brake.EffectiveValue = Input.GetAxis("Brake") * brake.BaseValue;

    }

}
