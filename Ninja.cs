using System;

namespace human
{
    public class Ninja : Human {
        public Ninja(string p) : base("Ninja") {
            dexterity = 175;
            player_name = p;
        }
        public void steal(object attacked) {
            base.attack(attacked);
            health += 10;
        }
        public void get_away() {
            health -= 15;
        }
        public static void get_options() {
            Console.WriteLine("Attack options: [a]ttack, [s]teal, [g]et away");
        }
    }
}