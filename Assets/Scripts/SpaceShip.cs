using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpaceShip : MonoBehaviour
{
    protected ShipMovementStat thrust = new ShipMovementStat();
    protected ShipMovementStat maxSpeed = new ShipMovementStat();
    protected ShipMovementStat rotation = new ShipMovementStat();
    protected ShipMovementStat brake = new ShipMovementStat();

    protected ShipCombatStat health = new ShipCombatStat();
    protected ShipCombatStat shield = new ShipCombatStat();
    protected ShipCombatStat heat = new ShipCombatStat();


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
        rb.AddRelativeForce(Vector2.up * thrust.EffectiveValue);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed.EffectiveValue);

        Quaternion q = Quaternion.AngleAxis((Mathf.Atan2(rotateToTarget.y - transform.position.y, rotateToTarget.x - transform.position.x) * Mathf.Rad2Deg) - 90, Vector3.forward);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, rotation.EffectiveValue * Time.deltaTime);

        rb.AddForce(-Vector2.ClampMagnitude(rb.velocity, brake.EffectiveValue));
    }
}
