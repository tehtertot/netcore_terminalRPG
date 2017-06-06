using System; 

namespace human
{

    public class Human {
        public string name, player_name;
        public int strength { get; set; }
        public int health { get; set; }
        public int intelligence { get; set; }
        public int dexterity { get; set; }
        public Human(string n) {
            name = n;
            strength = 3;
            intelligence = 3;
            dexterity = 3;
            health = 100;
        }
        public Human(string n, int s, int i, int d, int h) {
            name = n;
            strength = s;
            intelligence = i;
            dexterity = d;
            health = h;
        }

        public void attack(object o) {
            Enemy enemy = o as Enemy;
            if (enemy == null) {
                Console.WriteLine("Failed attack");
            }
            else {
                enemy.health -= strength * 5;
            }
        }

        // public void get_options() {
        //     Console.WriteLine("Attack options: [a]ttack");
        // }
    }

}