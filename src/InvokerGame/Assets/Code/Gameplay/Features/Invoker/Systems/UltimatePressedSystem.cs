using Code.Gameplay.Input.Service;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Invoker.Systems
{
    public class UltimatePressedSystem : IExecuteSystem
    {
        private readonly IInputService _inputService;
        private readonly IGroup<GameEntity> _invokers;

        public UltimatePressedSystem(GameContext game, IInputService inputService)
        {
            _inputService = inputService;
            _invokers = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Invoker));
        }

        public void Execute()
        {
            foreach (GameEntity invoker in _invokers)
            {
                if (_inputService.IsUltimatePressed)
                    invoker.isUltimatePressed = true;
                else if(invoker.isUltimatePressed)
                    invoker.isUltimatePressed = false;
            }
        }
    }
}