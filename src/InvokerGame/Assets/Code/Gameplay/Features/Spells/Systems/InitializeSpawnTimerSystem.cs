using Code.Common.Entity;
using Entitas;

namespace Code.Gameplay.Features.Spells.Systems
{
    public class InitializeSpawnTimerSystem : IInitializeSystem
    {
        public void Initialize()
        {
            CreateEntity.Empty()
                .AddSpawnTimer(10);
        }
    }
}