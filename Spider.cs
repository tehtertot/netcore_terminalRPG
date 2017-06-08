namespace human
{
    public class Spider : Enemy {
        public Spider(string p) : base("spider") {
            play_name = p;
        }

        public void attack(object o) {
            base.attack(o, 10, 20);
        }
    }
}