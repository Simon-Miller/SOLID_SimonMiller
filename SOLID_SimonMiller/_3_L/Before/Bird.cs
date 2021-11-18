namespace SOLID_SimonMiller._3_L.Before
{
    public abstract class Bird
    {
        public abstract string MakeNoise();

        public abstract string MoveTo(int x, int y);

        public abstract string Eat(string food);
    }

    public class Duck : Bird
    {
        public override string MakeNoise() => "Quack!";
        public override string MoveTo(int x, int y) => $"Swimms gracefully to x: {x}, y:{y}";

        public override string Eat(string food) => "Waggs tail feathers in appreciation.";
    }

    public class RubberDuck : Bird
    {
        public override string MakeNoise() => "Quack!";
        public override string MoveTo(int x, int y) => $"Swimms gracefully to x: {x}, y:{y}";

        // undesirable behaviour as a rubber duck is not really a Bird.   Breaking Liskov substitution.
        public override string Eat(string food) => throw new NotImplementedException();
    }
}
