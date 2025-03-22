using System;
using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Invoker;
using Code.Gameplay.Features.Spells.Factory;
using Code.Gameplay.StaticData;
using Entitas;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Gameplay.Features.Spells.Systems
{
    public class SpellSpawnSystem : IExecuteSystem
    {
        private readonly ITimeService _timeService;
        private readonly ISpellFactory _spellFactory;
        private readonly IStaticDataService _staticDataService;
        private readonly IGroup<GameEntity> _timers;
        private readonly IGroup<GameEntity> _invokers;

        public SpellSpawnSystem(GameContext game, ITimeService timeService, ISpellFactory spellFactory, IStaticDataService staticDataService)
        {
            _timeService = timeService;
            _spellFactory = spellFactory;
            _staticDataService = staticDataService;
            _timers = game.GetGroup(GameMatcher.SpawnTimer);
        }

        public void Execute()
        {
            foreach (GameEntity timer in _timers)
            {
                timer.ReplaceSpawnTimer(timer.SpawnTimer - _timeService.DeltaTime);

                if (timer.SpawnTimer <= 0)
                {
                    timer.ReplaceSpawnTimer(3);
                    SpawnSpell();
                }
            }
        }

        private void SpawnSpell()
        {
            SpellTypeId id = GetRandomId();

            _spellFactory.CreateSpell(
                id,
                at: RandomSpawnPosition(Vector3.zero),
                GetOrbsForCast(_staticDataService.GetSpellDefinition(id)));
        }
        
        private Vector3 RandomSpawnPosition(Vector3 invokerWorldPosition)
        {
            int range = Random.Range(-8, 8);

            Vector3 randomSpawnPosition = invokerWorldPosition + new Vector3(range, 6, 0);
            
            return randomSpawnPosition;
        }

        private SpellTypeId GetRandomId()
        {
            Array enumValues = Enum.GetValues(typeof(SpellTypeId));
            
            int randomIndex = Random.Range(1, enumValues.Length);
            
            return (SpellTypeId)enumValues.GetValue(randomIndex);
        }

        
        
        private List<OrbTypeId> GetOrbsForCast(SpellDefinition spellDefinition) =>
            spellDefinition.orbsForCast;
    }
}