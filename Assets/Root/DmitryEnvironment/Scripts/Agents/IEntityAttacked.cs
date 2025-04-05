namespace Root.Rak.Agents
{

    public enum TeamID { PLAYER, AGENT }

    public interface IEntityAttacked
    {
        TeamID ID { get; }

        void TakeDamage(IAttack attack);
    }
}