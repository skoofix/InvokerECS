using Code.Gameplay.Features.Orb.Factory;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Orb.Systems
{
    public class CreateOrbSystem : IExecuteSystem
    {
        private readonly IOrbFactory _orbFactory;
        private readonly IGroup<GameEntity> _inputs;

        public CreateOrbSystem(GameContext game, IOrbFactory orbFactory)
        {
            _orbFactory = orbFactory;
            _inputs = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Input, 
                    GameMatcher.SkillKey));
        }

        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            {
                _orbFactory.CreateOrb(MapKeyToOrb(input.SkillKey));
            }
        }
        
        private OrbTypeId MapKeyToOrb(KeyCode key)
        {
            return key switch
            {
                KeyCode.Q => OrbTypeId.Quas,
                KeyCode.W => OrbTypeId.Wex,
                KeyCode.E => OrbTypeId.Exort,
            };
        }
    }
}