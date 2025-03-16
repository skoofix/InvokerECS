using Entitas;

namespace Code.Gameplay.Features.Score
{
    [Game] public class Score : IComponent { public float Value; }
    [Game] public class Storage : IComponent {  }
    
    [Game] public class ScoreHolder : IComponent {  }
}