using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAUNTU_Homework1_
{
    internal class Weapons
    {
        public string name;
        public float addDamge;

        public Limah player;

        public void IncreaseDamage()
        {
            player.damageAmount += addDamge;
        }

        public void Upgrade()
        {
            addDamge += 1;
        }
    }
}
