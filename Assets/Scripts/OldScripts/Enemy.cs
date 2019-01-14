using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceRoguelike
{
    public class Enemy : SpaceShip
    {
        public GameObject enemyBullet;
        public GameObject playerShip;

        [SerializeField]
        private float initThrust = 3f;
        [SerializeField]
        private float initThrustHeat = 0.01f;
        [SerializeField]
        private float initMaxSpeed = 4f;
        [SerializeField]
        private float initRotation = 120f;
        [SerializeField]
        private float initBrake = 6f;
        [SerializeField]
        private float initBrakeHeat = 0.02f;
        [SerializeField]
        private float initHealth = 20f;
        [SerializeField]
        private float initShield = 50f;
        [SerializeField]
        private float initHeat = 100f;
        [SerializeField]
        private float initBasicAttackSpeed = 1f;


        protected override void Start()
        {


            thrust = new StatCalculator(initThrust);
            thrustHeat = new StatCalculator(initThrustHeat);
            maxSpeed = new StatCalculator(initMaxSpeed);
            rotation = new StatCalculator(initRotation);
            brake = new StatCalculator(initBrake);
            brakeHeat = new StatCalculator(initBrakeHeat);

            health = new PointBasedStat(initHealth, initHealth);
            shield = new PointBasedStat(initShield, initShield);
            heat = new PointBasedStat(0f, initHeat);
            basicAttackSpeed = new PointBasedStat(0f, initBasicAttackSpeed);

            base.Start();
        }

        protected override void Update()
        {

            targetPosition = playerShip.transform.position;

            if (Vector3.Distance(targetPosition, transform.position) >= 5f)
            {
                thrust.TotalMultiplier = 1f;
                brake.TotalMultiplier = 0f;
            }
            else
            {
                thrust.TotalMultiplier = 0f;
                brake.TotalMultiplier = 1f;
            }


            if (!basicAttackSpeed.IsValueZero)
            {
                basicAttackSpeed.CurrentValue -= Time.deltaTime * basicAttackSpeed.MaxValue.EffectiveStat;
            }
            else
            {
                BasicAttack();
            }

            base.Update();
        }



        protected override void FixedUpdate()
        {

            myRigidbody2D.velocity = Vector2.ClampMagnitude(myRigidbody2D.velocity, maxSpeed.EffectiveStat);

            base.FixedUpdate();

        }



        private void BasicAttack()
        {

            Vector3 offset = transform.rotation * Vector3.up;

            Instantiate(enemyBullet, transform.position + offset, transform.rotation);

            basicAttackSpeed.CurrentValue = basicAttackSpeed.MaxValue.EffectiveStat;

        }


    }
}
