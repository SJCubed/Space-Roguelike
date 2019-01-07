using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpaceShip : MonoBehaviour
{


    protected StatCalculator thrust = new StatCalculator();
    protected StatCalculator thrustHeat = new StatCalculator();
    protected StatCalculator maxSpeed = new StatCalculator();
    protected StatCalculator rotation = new StatCalculator();
    protected StatCalculator brake = new StatCalculator();
    protected StatCalculator brakeHeat = new StatCalculator();
    protected PointBasedStat health = new PointBasedStat();
    protected PointBasedStat shield = new PointBasedStat();
    protected PointBasedStat heat = new PointBasedStat();

    protected Vector2 rotateToTarget;

    private Rigidbody2D rb;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {

    }

    private void FixedUpdate()
    {
        MoveShip();
    }

    protected void MoveShip()
    {
        //Forward Thrust
        rb.AddRelativeForce(Vector2.up * thrust.EffectiveStat);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed.EffectiveStat);
        //Rotation
        Quaternion q = Quaternion.AngleAxis((Mathf.Atan2(rotateToTarget.y - transform.position.y, rotateToTarget.x - transform.position.x) * Mathf.Rad2Deg) - 90, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, rotation.EffectiveStat * Time.deltaTime);
        //Brake
        rb.AddForce(-Vector2.ClampMagnitude(rb.velocity, brake.EffectiveStat));
        //Heat



        Debug.Log("Current Heat: " + heat.CurrentValue + "/ Max Heat: " + heat.MaxValue.EffectiveStat);

    }

}
