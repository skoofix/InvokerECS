using Code.Gameplay.Features.Score.Behaviours;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Score.Registrars
{
    public class ScoreUIRegistrar : EntityComponentRegistrar
    {
        public ScoreUI ScoreUI;
    
        public override void RegisterComponents() => 
            Entity.AddScoreUI(ScoreUI);

        public override void UnregisterComponents()
        {
            if (Entity.hasActiveOrbsUI)
                Entity.RemoveActiveOrbsUI();
        }
    }
}