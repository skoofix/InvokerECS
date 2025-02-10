using UnityEngine;

namespace Code.Gameplay.Features.Spells.Behaviours
{
    public class SpellAnimator : MonoBehaviour
    {
        private readonly int _diedHash = Animator.StringToHash("died");
    
        public Animator Animator;
        
        public void PlayDied() => Animator.SetTrigger(_diedHash);
    }
}