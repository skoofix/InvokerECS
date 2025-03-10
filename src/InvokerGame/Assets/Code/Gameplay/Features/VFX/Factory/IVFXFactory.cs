using UnityEngine;

namespace Code.Gameplay.Features.VFX.Factory
{
    public interface IVFXFactory
    {
        GameEntity CreateExplosionVFX(Vector3 at);
    }
}