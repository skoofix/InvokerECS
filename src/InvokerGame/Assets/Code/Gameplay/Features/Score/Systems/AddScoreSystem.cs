using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Score.Systems
{
    public class AddScoreSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _storages;

        public AddScoreSystem(GameContext game) : base(game)
        {
            _storages = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Storage,
                    GameMatcher.Score));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.ActivatedSpell.Added());

        protected override bool Filter(GameEntity entity) => entity.isSpell & entity.hasScore;

        protected override void Execute(List<GameEntity> activatedSpells)
        {
            foreach (GameEntity storage in _storages)
            foreach (GameEntity spell in activatedSpells)
            {
                storage.ReplaceScore(storage.Score + spell.Score);
            }
        }
    }
}