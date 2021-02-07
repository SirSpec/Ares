using GameSystem.Weapons;

namespace GameSystem
{
    public interface ITarget
    {
        void TakeDamage(DamageDealt damage);
    }
}