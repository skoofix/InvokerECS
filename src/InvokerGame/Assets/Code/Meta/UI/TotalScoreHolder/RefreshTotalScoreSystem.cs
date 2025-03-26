using Code.Meta.UI.TotalScoreHolder.Service;
using Entitas;
using UnityEngine;

namespace Code.Meta.UI.TotalScoreHolder
{
    public class RefreshTotalScoreSystem : IInitializeSystem
    {
        private readonly ITotalScoreUIService _totalScoreUIService;
        private readonly IGroup<MetaEntity> _storages;

        public RefreshTotalScoreSystem(MetaContext metaContext, ITotalScoreUIService totalScoreUIService)
        {
            _totalScoreUIService = totalScoreUIService;

            _storages = metaContext.GetGroup(MetaMatcher.AllOf(MetaMatcher.Storage, MetaMatcher.TotalScore));
        }
        
        public void Initialize()
        {
            foreach (MetaEntity storage in _storages)
            {
                _totalScoreUIService.UpdateTotalScore(storage.TotalScore);
            }
        }
    }
}