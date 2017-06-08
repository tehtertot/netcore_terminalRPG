using System;

namespace human
{
    public class Enemy {
        public string name, play_name;
        public int strength { get; set; }
        public int health { get; set; }

        public Enemy(string n) {
            name = n;
            strength = 3;
            health = 100;
        }

        public void attack(object o, int start, int end) {
            Human hero = o as Human;
            Random rand = new Random();
            int r = rand.Next(start, end);
            if (hero == null) {
                Console.WriteLine("Failed attack");
            }
            else {
                hero.health -= strength * r;
            }
            
        }
    }
}