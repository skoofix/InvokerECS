using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Score.Systems
{
    public class UpdateScoreUISystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _scoreUIs;

        public UpdateScoreUISystem(GameContext game) : base(game)
        {
            _scoreUIs = game.GetGroup(GameMatcher.ScoreUI);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Score.Added());

        protected override bool Filter(GameEntity entity) => entity.isInvoker;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity scoreUI in _scoreUIs)
            foreach (GameEntity entity in entities)
            {
                scoreUI.ScoreUI.SetScore(entity.Score);
            }
        }
    }

}