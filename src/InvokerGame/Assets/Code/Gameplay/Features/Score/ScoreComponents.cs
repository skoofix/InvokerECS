using Code.Gameplay.Features.Score.Behaviours;
using Code.Progress;
using Entitas;

namespace Code.Gameplay.Features.Score
{
    [Game] public class Score : IComponent { public float Value; }
    [Game] public class ScoreUIComponent : IComponent { public ScoreUI Value; }
    [Meta] public class TotalScore : ISavedComponent { public float Value; }
    [Meta] public class Storage : ISavedComponent {  }
}