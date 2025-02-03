using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Spells.Factory;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Spells.Systems
{
    public class SpellSpawnSystem : IExecuteSystem
    {
        private readonly ITimeService _timeService;
        private readonly ISpellFactory _spellFactory;
        private readonly IGroup<GameEntity> _timers;
        private readonly IGroup<GameEntity> _invokers;

        public SpellSpawnSystem(GameContext game, ITimeService timeService, ISpellFactory spellFactory)
        {
            _timeService = timeService;
            _spellFactory = spellFactory;
            _timers = game.GetGroup(GameMatcher.SpawnTimer);
            _invokers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Invoker, 
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity invoker in _invokers)
            foreach (GameEntity timer in _timers)
            {
                timer.ReplaceSpawnTimer(timer.SpawnTimer - _timeService.DeltaTime);

                if (timer.SpawnTimer <= 0)
                {
                    timer.ReplaceSpawnTimer(10);
                    _spellFactory.CreateSpell(SpellTypeId.ColdSnap, at: RandomSpawnPosition(invoker.WorldPosition));
                }
            }
        }

        private Vector3 RandomSpawnPosition(Vector3 invokerWorldPosition)
        {
            int range = Random.Range(1, 3);
            int range2 = Random.Range(1, 3);

            return invokerWorldPosition + new Vector3(range, range2, 0);
        }
    }
}