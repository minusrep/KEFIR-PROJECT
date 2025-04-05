using Root.Rak.Agents;

namespace Root.Rak.Tests
{
    public class TestAttack : IAttack
    {
        public float Damage { get; private set; }

        public TestAttack(float damage)
        {
            Damage = damage;
        }
    }
}