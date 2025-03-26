using System.Collections.Generic;
using System.Linq;
using Code.Infrastructure.Serialization;
using Code.Progress.Data;
using Code.Progress.Provider;
using UnityEngine;

namespace Code.Progress.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string PlayerProgressKey = "PlayerProgress";
        
        private readonly MetaContext _metaContext;
        private readonly IProgressProvider _progressProvider;

        public bool HasSavedProgress => PlayerPrefs.HasKey(PlayerProgressKey);

        public SaveLoadService(MetaContext metaContext, IProgressProvider progressProvider)
        {
            _metaContext = metaContext;
            _progressProvider = progressProvider;
        }

        public void CreateProgress()
        {
            _progressProvider.SetProgressData(new ProgressData());
        }

        public void SaveProgress()
        {
            PreserveMetaEntities();
            PlayerPrefs.SetString(PlayerProgressKey, _progressProvider.ProgressData.ToJson());
            PlayerPrefs.Save();
        }

        public void LoadProgress()
        {
            HydrateProgress(PlayerPrefs.GetString(PlayerProgressKey));
        }

        private void HydrateProgress(string serializedProgress)
        {
            _progressProvider.SetProgressData(serializedProgress.FromJson<ProgressData>());
            HydrateMetaEntities();
        }

        private void HydrateMetaEntities()
        {
            List<EntitySnapshot> snapshots = _progressProvider.EntityData.GameEntitySnapshots;

            foreach (EntitySnapshot snapshot in snapshots)
            {
                _metaContext
                    .CreateEntity()
                    .HydrateWith(snapshot);
            }
        }

        private void PreserveMetaEntities()
        {
            _progressProvider.EntityData.GameEntitySnapshots = _metaContext
                .GetEntities()
                .Where(RequiresSave)
                .Select(e => e.AsSavedEntity())
                .ToList();
        }

        private static bool RequiresSave(MetaEntity e)
        {
            return e.GetComponents().Any(c => c is ISavedComponent );
        }
    }
}