using Code.Common.Destruct;
using Code.Infrastructure.Systems;
using Code.Meta.UI.TotalScoreHolder;

namespace Code.Meta
{
    public class HomeScreenFeature : Feature
    {
        public HomeScreenFeature(ISystemFactory systems)
        {
            Add(systems.Create<RefreshTotalScoreSystem>());
            
            Add(systems.Create<ProcessDestructedFeature>());
        }        
    }
}