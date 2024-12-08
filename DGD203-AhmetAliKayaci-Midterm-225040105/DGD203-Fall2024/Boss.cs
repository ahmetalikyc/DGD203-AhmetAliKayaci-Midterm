namespace SuperHeroSimulation
{
    public class Boss
    {
        #region VARIABLES
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }

        private static Random _rand = new Random();
        #endregion

        #region CONSTRUCTOR
        public Boss(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
        #endregion

        #region METHODS
        public bool IsAlive() => Health > 0;

        public void TakeDamage(int damage)
        {
            if (damage > 0)
            {
                Health -= damage;
                Console.WriteLine($"{Name} took {damage} damage! Health: {Health}");
            }
        }

        public string BossAttack()
        {
            return _rand.Next(0, 2) == 0 ? "left" : "right";  
        }
        #endregion
    }
}