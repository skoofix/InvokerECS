using RSG;

namespace Code.Infrastructure.States.StateInfrastructure
{
    public class SimplePayloadState<TPayload> : IPayloadState<TPayload>
    {
        public virtual void Enter(TPayload payload)
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