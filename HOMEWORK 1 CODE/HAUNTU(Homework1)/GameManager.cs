using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HAUNTU_Homework1_
{
    internal class GameManager
    {
        public Levels currentLevel;
        public Limah player;
        public HantU hantU;
        public PowerUp powerUps;

        public void StartGame()
        {
            // Initialize game start logic
        }

        public void EndGame()
        {
            if(player.currentHealth == 0) {
                Console.WriteLine("Game Over!");
            }
        }

        public void UpdateGame()
        {
            Random random = new Random();
            int randomSpawnPointX = random.Next(0, 20);
            int randomSpawnPointY = random.Next(0, 20);
            currentLevel.SpawnEnemies(randomSpawnPointX, randomSpawnPointY);

            int randomSpawnPowerUp = random.Next(1, 5);
            if(hantU.currentHealth == 0)
            {
                powerUps.ApplyEffect();
            }
        }
    }
}
