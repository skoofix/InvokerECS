using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Score;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Progress.SaveLoad;
using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
    public class InitializeProgressState : SimpleState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly ISaveLoadService _saveLoadService;

        public InitializeProgressState(IGameStateMachine stateMachine, ISaveLoadService saveLoadService)
        {
            _stateMachine = stateMachine;
            _saveLoadService = saveLoadService;
        }

        public override void Enter()
        {
            InitializeProgress();

            _stateMachine.Enter<LoadingHomeScreenState>();
        }

        private void InitializeProgress()
        {
            if (_saveLoadService.HasSavedProgress)
            {
                _saveLoadService.LoadProgress();
                Debug.Log("Загрузил");
            }
            else
            {
                CreateNewProgress();
                Debug.Log("Создал новые");
            }
        }

        private void CreateNewProgress()
        {
            _saveLoadService.CreateProgress();

            CreateMetaEntity.Empty()
                .With(x => x.isStorage = true)
                .AddTotalScore(0);
        }
    }
}