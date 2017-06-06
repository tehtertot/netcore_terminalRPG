namespace human
{
    public class Zombie : Enemy {
        public Zombie() : base("zombie") {
            health = 200;
        }

        public void attack(object o) {
            base.attack(o, 15, 25);
        }
    }
}