using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HAUNTU_Homework1_
{
    internal class Limah : GameObj
    {
        public float moveSpeed;
        public float currentHealth;
        public float maxHealth;
        public float damageAmount;

        public Vector2 movement;
        public HantU hantU;

        public Limah(Vector2 position) : base(position)
        {
            this.movement = position;
        }

        public void Start()
        {
            currentHealth = maxHealth;
        }

        public void Update()
        {
            Move();
        }

        public void Move()
        {
            movement.X = this.position.X + moveSpeed;
            movement.Y = this.position.Y + moveSpeed;
        }

        public void Attack()
        {
            hantU.Damage(damageAmount);
        }

        public void TakeDamage(float amount)
        {
            this.currentHealth -= amount;
        }
    }
}
