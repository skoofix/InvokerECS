namespace Code.Gameplay.Features.Orb.Factory
{
    public interface IOrbFactory
    {
        GameEntity CreateQuasOrb();
        GameEntity CreateWexOrb();
        GameEntity CreateExortOrb();
        GameEntity CreateOrb(OrbTypeId type);
    }
}