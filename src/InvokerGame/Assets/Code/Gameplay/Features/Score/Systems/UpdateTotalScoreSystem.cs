using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Score.Systems
{
    public class UpdateTotalScoreSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<MetaEntity> _storages;

        public UpdateTotalScoreSystem(GameContext game, MetaContext meta) : base(game)
        {
            _storages = meta.GetGroup(
                MetaMatcher
                    .AllOf(
                        MetaMatcher.Storage, 
                        MetaMatcher.TotalScore));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.AllOf(GameMatcher.Invoker, GameMatcher.Dead).Added());

        protected override bool Filter(GameEntity invoker) => invoker.isDead;

        protected override void Execute(List<GameEntity> invokers)
        {
            foreach (GameEntity invoker in invokers)
            foreach (MetaEntity storage in _storages)
            {
                if (invoker.Score > storage.TotalScore)
                {
                    storage.ReplaceTotalScore(invoker.Score);
                }
            }
        }
    }
}