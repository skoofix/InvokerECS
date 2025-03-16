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
        
        private readonly GameContext _gameContext;
        private readonly IProgressProvider _progressProvider;
        public bool HasSavedProgress => PlayerPrefs.HasKey(PlayerProgressKey);

        public SaveLoadService(GameContext gameContext, IProgressProvider progressProvider)
        {
            _gameContext = gameContext;
            _progressProvider = progressProvider;
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
            HydrateGameEntities();
        }

        private void HydrateGameEntities()
        {
            List<EntitySnapshot> snapshots = _progressProvider.EntityData.GameEntitySnapshots;

            foreach (EntitySnapshot snapshot in snapshots)
            {
                _gameContext
                    .CreateEntity()
                    .HydrateWith(snapshot);
            }
        }

        private void PreserveMetaEntities()
        {
            _progressProvider.EntityData.GameEntitySnapshots = _gameContext
                .GetEntities()
                .Where(RequiresSave)
                .Select(e => e.AsSavedEntity())
                .ToList();
        }

        private static bool RequiresSave(GameEntity e)
        {
            return e.GetComponents().Any(c => c is ISavedComponent );
        }
    }
}