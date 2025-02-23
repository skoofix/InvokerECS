using Code.Gameplay.Features.Invoker.Behaviours;
using Code.Infrastructure.View.Registrars;

public class OrbsUIRegistrar : EntityComponentRegistrar
{
    public OrbsUI OrbsUI;
    
    public override void RegisterComponents() => 
        Entity.AddActiveOrbsUI(OrbsUI);

    public override void UnregisterComponents()
    {
        if (Entity.hasActiveOrbsUI)
            Entity.RemoveActiveOrbsUI();
    }
}
