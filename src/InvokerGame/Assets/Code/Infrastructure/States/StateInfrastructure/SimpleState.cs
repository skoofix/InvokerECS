using RSG;

namespace Code.Infrastructure.States.StateInfrastructure
{
    public class SimpleState : IState
    {
        public virtual void Enter()
        {
            
        }

        virtual protected void Exit()
        {
            
        }
        
        IPromise IExitableState.BeginExit()
        {
            Exit();
            return Promise.Resolved();
        }

        void IExitableState.EndExit() {}
    }
}