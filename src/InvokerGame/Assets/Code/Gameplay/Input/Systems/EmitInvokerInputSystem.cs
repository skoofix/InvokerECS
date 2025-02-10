using Code.Gameplay.Input.Service;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Input.Systems
{
    public class EmitInvokerInputSystem : IExecuteSystem
    {
        private readonly IInputService _inputService;
        private readonly IGroup<GameEntity> _inputs;

        public EmitInvokerInputSystem(GameContext game, IInputService inputService)
        {
            _inputService = inputService;
            _inputs = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Input));
        }

        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            {
                if (_inputService.GetKeyDown(KeyCode.Q))
                    input.ReplaceSkillKey(KeyCode.Q);
                else if (_inputService.GetKeyDown(KeyCode.W))
                    input.ReplaceSkillKey(KeyCode.W);
                else if (_inputService.GetKeyDown(KeyCode.E))
                    input.ReplaceSkillKey(KeyCode.E);
                else if (input.hasSkillKey)
                    input.RemoveSkillKey();
            }
        }
    }
}