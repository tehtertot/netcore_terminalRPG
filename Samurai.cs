using System;

namespace human
{
    
    public class Samurai : Human {
        public static int count = 0;
        public Samurai(string p) : base("Samurai") {
            player_name = p;
            health = 200;
            count++;
        }
        public void death_blow(object attacked) {
            Human enemy = attacked as Human;
            if (enemy.health < 50) {
                enemy.health = 0;
            }
        }
        public void meditate() {
            health = 200;
        }
        public static int how_many() {
            return count;
        }
        public static void get_options() {
            Console.WriteLine("Attack options: [a]ttack, [d]eath blow, [m]editate");
        }
    }
}