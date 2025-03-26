using System;

namespace Code.Meta.UI.TotalScoreHolder.Service
{
    public interface ITotalScoreUIService
    {
        float TotalScore { get; }
        void UpdateTotalScore(float score);
        event Action TotalScoreChanged;
    }
}