namespace human
{
    public class Zombie : Enemy {
        public Zombie(string p) : base("zombie") {
            play_name = p;
            health = 200;
        }

        public void attack(object o) {
            base.attack(o, 15, 25);
        }
    }
}