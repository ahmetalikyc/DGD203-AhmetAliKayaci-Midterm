namespace SuperHeroSimulation
{
    public class Player
    {
        #region VARIABLES
        public string Name { get; private set; }
        public int Strength { get; private set; }
        public int Speed { get; private set; }
        public int Intelligence { get; private set; }
        public int Health { get; set; }
        #endregion

        #region CONSTRUCTOR
        public Player(string name, int strength, int speed, int intelligence, int health = 100)
        {
            Name = name;
            Strength = strength;
            Speed = speed;
            Intelligence = intelligence;
            Health = health;
        }
        #endregion

        #region METHODS
        public int CalculateDamage(string target)
        {
            int damage = 0;
            if (Strength == 1) { damage = target == "head" ? 5 : 1; }
            else if (Strength == 2) { damage = target == "head" ? 10 : 3; }
            else if (Strength == 3) { damage = target == "head" ? 15 : 5; }
            else if (Strength == 4) { damage = target == "head" ? 20 : 10; }
            else if (Strength == 5) { damage = target == "head" ? 25 : 15; }
            else if (Strength == 6) { damage = target == "head" ? 30 : 20; }
            else if (Strength == 7) { damage = target == "head" ? 35 : 25; }
            else if (Strength == 8) { damage = target == "head" ? 40 : 30; }
            else if (Strength == 9) { damage = target == "head" ? 45 : 35; }
            else if (Strength == 10) { damage = target == "head" ? 50 : 40; }
            return damage;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"{Name} took {damage} damage! Health: {Health}");
        }

        public void DisplayStats()
        {
            Console.WriteLine($"{Name} - Strength: {Strength}, Speed: {Speed}, Intelligence: {Intelligence}, Health: {Health}");
        }
        #endregion
    }
}