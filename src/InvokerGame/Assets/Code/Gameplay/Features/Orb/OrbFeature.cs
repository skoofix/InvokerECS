using Code.Gameplay.Features.Orb.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Orb
{
    public class OrbFeature : Feature
    {
        public OrbFeature(ISystemFactory systems)
        {
            Add(systems.Create<CreateOrbSystem>());
            Add(systems.Create<AddOrbToActiveSystem>());
        }
    }
}