using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAUNTU_Homework1_
{
    internal class PowerUp
    {
        public float duration;

        public Limah player;

        public void ApplyEffect()
        {
            Random random = new Random();
            int randomPowerUpNum = random.Next(1, 3);

            if(randomPowerUpNum == 1) { 
                player.moveSpeed += 1;
            }else if(randomPowerUpNum == 2) {
                player.maxHealth += 5;
            }else if(randomPowerUpNum == 3) {
                player.damageAmount += 1;
            }
        }
    }
}
