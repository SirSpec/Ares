using Ares.GameSystem.Weapons;

namespace Ares.GameSystem
{
    public interface ITarget
    {
        void TakeDamage(DamageDealt damage);
    }
}