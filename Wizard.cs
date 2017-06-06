using System;

namespace human
{
    public class Wizard : Human {
        public Wizard(string p) : base("Wizard"){
            health = 50;
            intelligence = 25;
            player_name = p;
        }
        public void heal() {
            health += intelligence*10;
        }
        public void fireball(object attacked) {
            Human enemy = attacked as Human;
            Random rand = new Random();
            int r = rand.Next(20,51);
            enemy.health -= r;
        }
        public static void get_options() {
            Console.WriteLine("Attack options: [a]ttack, [h]eal, [f]ireball");
        }
    }
}