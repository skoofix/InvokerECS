﻿using System.Collections.Generic;
using Entitas;

namespace Code.Common.Destruct.Systems
{
    public class CleanupMetaDestructedSystem : ICleanupSystem
    {
        private readonly IGroup<MetaEntity> _entities;
        private readonly List<MetaEntity> _buffer = new(64);

        public CleanupMetaDestructedSystem(MetaContext meta)
        {
            _entities = meta.GetGroup(MetaMatcher.Destructed);
        }

        public void Cleanup()
        {
            foreach (MetaEntity entity in _entities.GetEntities(_buffer))
                entity.Destroy();
        }
    }
}