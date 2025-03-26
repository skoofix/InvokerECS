using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Score.Systems
{
    public class AddScoreSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _invokers;

        public AddScoreSystem(GameContext game) : base(game)
        {
            _invokers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Invoker,
                    GameMatcher.Score));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.ActivatedSpell.Added());

        protected override bool Filter(GameEntity entity) => entity.isSpell & entity.hasScore;

        protected override void Execute(List<GameEntity> activatedSpells)
        {
            foreach (GameEntity invoker in _invokers)
            foreach (GameEntity spell in activatedSpells)
            {
                invoker.ReplaceScore(invoker.Score + spell.Score);
            }
        }
    }
}