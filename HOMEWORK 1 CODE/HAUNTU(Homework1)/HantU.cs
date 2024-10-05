using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HAUNTU_Homework1_
{
    internal class HantU : GameObj
    {
        public string hantUName;
        public float moveSpeed;
        public float currentHealth;
        public float maxHealth;
        public float damageAmount;

        public Limah player;

        public HantU(Vector2 position) : base(position)
        {
        }

        public void Update()
        {
            FollowPlayer();
            if (currentHealth == 0)
            {
                Console.WriteLine(hantUName + " defeated!");
            }
        }

        public void FollowPlayer()
        { 
            this.position.X = player.position.X;
            this.position.Y = player.position.Y;
        }

        public void Attacking()
        {
            player.TakeDamage(damageAmount);
        }

        public void Damage(float amount)
        {
            this.currentHealth -= amount;
        }
    }
}
