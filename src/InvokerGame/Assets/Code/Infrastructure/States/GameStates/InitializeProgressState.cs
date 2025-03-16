using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Progress.Data;
using Code.Progress.Provider;
using Code.Progress.SaveLoad;

namespace Code.Infrastructure.States.GameStates
{
  public class InitializeProgressState : IState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly IProgressProvider _progressProvider;
    private readonly ISaveLoadService _saveLoadService;

    public InitializeProgressState(
      IGameStateMachine stateMachine,
      IProgressProvider progressProvider,
      ISaveLoadService saveLoadService)
    {
      _stateMachine = stateMachine;
      _progressProvider = progressProvider;
      _saveLoadService = saveLoadService;
    }
    
    public void Enter()
    {
      InitializeProgress();

      _stateMachine.Enter<LoadingHomeScreenState>();
    }

    private void InitializeProgress()
    {
      if (_saveLoadService.HasSavedProgress)
        _saveLoadService.LoadProgress();
      else
        CreateNewProgress();
    }

    private void CreateNewProgress()
    {
      _progressProvider.SetProgressData(new ProgressData());
    }

    public void Exit()
    {
    }
  }
}