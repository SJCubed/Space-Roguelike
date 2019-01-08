using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SpaceShip : MonoBehaviour
{

    public Text Hit;

    private string hit = "";

    private static PointBasedStat UICooldown;

    protected StatCalculator thrust;
    protected StatCalculator thrustHeat;
    protected StatCalculator maxSpeed;
    protected StatCalculator rotation;
    protected StatCalculator brake;
    protected StatCalculator brakeHeat;
    protected PointBasedStat health;
    protected PointBasedStat shield;
    protected PointBasedStat heat;
    protected PointBasedStat basicAttackSpeed;

    protected Vector2 targetPosition;

    protected Rigidbody2D myRigidbody2D;

    protected virtual void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();

        UICooldown = new PointBasedStat(0f, 1.5f);

    }

    protected virtual void Update()
    {

        if (UICooldown.IsValueZero)
        {
            hit = "";
        }
        else
        {
            UICooldown.CurrentValue -= Time.deltaTime;
        }

        Hit.text = hit;

    }

    protected virtual void FixedUpdate()
    {
        MoveShip();
    }

    protected void MoveShip()
    {
        //Forward Thrust
        myRigidbody2D.AddRelativeForce(Vector2.up * thrust.EffectiveStat);

        //Rotation
        Quaternion q = Quaternion.AngleAxis((Mathf.Atan2(targetPosition.y - transform.position.y, targetPosition.x - transform.position.x) * Mathf.Rad2Deg) - 90, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, rotation.EffectiveStat * Time.deltaTime);
        //Brake
        if (brake.EffectiveStat > 0)
        {
            if (myRigidbody2D.velocity.magnitude >= brake.EffectiveStat / 2)
            {
                myRigidbody2D.AddForce(-Vector2.ClampMagnitude(myRigidbody2D.velocity, brake.EffectiveStat));

            }
            else
            {
                myRigidbody2D.velocity = Vector2.zero;
            }
        }


        //Heat

        //Debug.Log("Current Heat: " + heat.CurrentValue + "/ Max Heat: " + heat.MaxValue.EffectiveStat);

    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (shield.CurrentValue > 0)
        {
            shield.CurrentValue -= 30;
            if (shield.IsValueZero)
            {
                health.CurrentValue -= shield.UnderflowValue;
            }
        }
        else
        {
            health.CurrentValue -= 30;
            if (health.IsValueZero)
            {
                DestroyShip();
            }
        }

        if (gameObject.layer == 8)
        {
            hit = "Player took 30 dmg!";
        }
        else
        {
            hit = "Enemy took 30 dmg!";
        }

        UICooldown.CurrentValue = UICooldown.MaxValue.EffectiveStat;

    }

    protected void DestroyShip()
    {

        if (gameObject.layer == 8)
        {

            Debug.Log("Player has died. Respawning.");

            health.CurrentValue = health.MaxValue.EffectiveStat;
            shield.CurrentValue = shield.MaxValue.EffectiveStat;
            transform.position = Vector2.zero;

        }
        else
        {
            Destroy(gameObject);
        }


    }




}
