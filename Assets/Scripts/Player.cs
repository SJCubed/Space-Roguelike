using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : SpaceShip
{

    public GameObject playerBullet;

    public Text PlayerHealth;

    private StatCalculator boost;
    private PointBasedStat boostDuration;
    private PointBasedStat boostCooldown;

    [SerializeField]
    private float initThrust = 5f;
    [SerializeField]
    private float initThrustHeat = 0.01f;
    [SerializeField]
    private float initMaxSpeed = 8f;
    [SerializeField]
    private float initRotation = 180f;
    [SerializeField]
    private float initBrake = 6f;
    [SerializeField]
    private float initBrakeHeat = 0.02f;
    [SerializeField]
    private float initBoost = 15f;
    [SerializeField]
    private float initBoostDuration = 0.2f;
    [SerializeField]
    private float initBoostCooldown = 1f;
    [SerializeField]
    private float initHealth = 100f;
    [SerializeField]
    private float initShield = 100f;
    [SerializeField]
    private float initHeat = 100f;
    [SerializeField]
    private float initBasicAttackSpeed = 2f;


    protected override void Start()
    {

        thrust = new StatCalculator(initThrust);
        thrustHeat = new StatCalculator(initThrustHeat);
        maxSpeed = new StatCalculator(initMaxSpeed);
        rotation = new StatCalculator(initRotation);
        brake = new StatCalculator(initBrake);
        brakeHeat = new StatCalculator(initBrakeHeat);
        boost = new StatCalculator(initBoost);

        boostDuration = new PointBasedStat(0f, initBoostDuration);
        boostCooldown = new PointBasedStat(0f, initBoostCooldown);
        health = new PointBasedStat(initHealth, initHealth);
        shield = new PointBasedStat(initShield, initShield);
        heat = new PointBasedStat(0f, initHeat);
        basicAttackSpeed = new PointBasedStat(0f, initBasicAttackSpeed);


        base.Start();
    }

    protected override void Update()
    {

        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        thrust.TotalMultiplier = Input.GetAxis("Thrust");
        brake.TotalMultiplier = Input.GetAxis("Brake");

        GetPlayerInput();

        PlayerHealth.text = "Player  |  Shield:  " + shield.CurrentValue + "  /  " + shield.MaxValue.EffectiveStat + "  Health:  " + health.CurrentValue + "  /  " + health.MaxValue.EffectiveStat;

        if (!boostDuration.IsValueZero)
            boostDuration.CurrentValue -= Time.deltaTime;

        if (!boostCooldown.IsValueZero)
            boostCooldown.CurrentValue -= Time.deltaTime;

        if (!basicAttackSpeed.IsValueZero)
            basicAttackSpeed.CurrentValue -= Time.deltaTime * basicAttackSpeed.MaxValue.EffectiveStat;

        base.Update();
    }



    protected override void FixedUpdate()
    {

        if (boostDuration.IsValueZero)
        {
            myRigidbody2D.velocity = Vector2.ClampMagnitude(myRigidbody2D.velocity, maxSpeed.EffectiveStat);

        }

        if (Input.GetButton("MovementSkill") && boostCooldown.IsValueZero)
        {
            MovementSkill();
        }

        base.FixedUpdate();

    }


    private void GetPlayerInput()
    {

        if (Input.GetButton("BasicAttack") && basicAttackSpeed.IsValueZero)
        {
            BasicAttack();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }


    }

    private void BasicAttack()
    {

        Vector3 offset = transform.rotation * Vector3.up;

        Instantiate(playerBullet, transform.position + offset, transform.rotation);

        basicAttackSpeed.CurrentValue = basicAttackSpeed.MaxValue.EffectiveStat;

    }



    private void MovementSkill()
    {
        Vector2 boostVector = Vector2.ClampMagnitude(new Vector2(targetPosition.x - transform.position.x, targetPosition.y - transform.position.y), 1f);
        myRigidbody2D.AddForce(boostVector * boost.EffectiveStat, ForceMode2D.Impulse);

        boostDuration.CurrentValue = boostDuration.MaxValue.EffectiveStat;
        boostCooldown.CurrentValue = boostCooldown.MaxValue.EffectiveStat;

    }

    private void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;

        }
        else
        {
            Time.timeScale = 1;
        }
    }


}
