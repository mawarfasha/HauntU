using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAUNTU_Homework1_
{
    internal class Levels
    {
        public int difficultyLevel;
        public float setTimer;
        public float countdown;
        public int swarm;

        public HantU hantU;

        public void Update()
        {
            if(countdown < 0)
            {
                countdown = setTimer;
            }
            else
            {
                countdown -= 0.1f;
            }
        }

        public void SpawnEnemies(int spawnPointX, int spawnPointY)
        {
            if (countdown >= 0)
            {
                for (int i = 1; i <= swarm; i++)
                {
                    hantU.position.X = spawnPointX;
                    hantU.position.Y = spawnPointY;
                }
            }
            
        }
    }
}
