using Code.Gameplay.Features.Spells.Behaviours;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Spells.Registrars
{
    public class SpellAnimatorRegistrar : EntityComponentRegistrar
    {
        public SpellAnimator SpellAnimator;
        
        public override void RegisterComponents()
        {
            Entity
                .AddSpellAnimator(SpellAnimator);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasSpellAnimator)
                Entity.RemoveSpellAnimator();
        }
    }
}