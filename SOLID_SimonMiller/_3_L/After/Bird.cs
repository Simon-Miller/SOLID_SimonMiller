namespace SOLID_SimonMiller._3_L.After
{
    public abstract class Bird
    {
        public abstract string MakeNoise();

        public abstract string MoveTo(int x, int y);
    }

    public abstract class LivingBird : Bird
    {
        public abstract string Eat(string food);
    }

    public class Duck : LivingBird
    {
        public override string MakeNoise() => "Quack!";
        public override string MoveTo(int x, int y) => $"Swimms gracefully to x: {x}, y:{y}";

        public override string Eat(string food) => "Waggs tail feathers in appreciation.";
    }

    public class RemoteControlledRubberDuck : Bird
    {
        public override string MakeNoise() => "Squeek!";
        public override string MoveTo(int x, int y) => $"Paddles irratically to x: {x}, y:{y} thanks to the remote controller.";
    }

    /*
     NOTE: Both a Duck and RubberDuck share the Bird base class, and therefore you can swap one Bird for another without undesirable side-effects.
            Or if you want, both Duck and RubberDuck are completely replaceable by something else that derives from the base class (Bird)
     */
}
