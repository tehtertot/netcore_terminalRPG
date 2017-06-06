namespace human
{
    public class Spider : Enemy {
        public Spider() : base("spider") {
        }

        public void attack(object o) {
            base.attack(o, 10, 20);
        }
    }
}