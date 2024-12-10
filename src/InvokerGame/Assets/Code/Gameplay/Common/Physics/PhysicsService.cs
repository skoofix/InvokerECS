using System.Collections.Generic;
using Code.Gameplay.Common.Collisions;
using UnityEngine;

namespace Code.Gameplay.Common.Physics
{
  public class PhysicsService : IPhysicsService
  {
    private static readonly RaycastHit2D[] Hits = new RaycastHit2D[128];
    private static readonly Collider2D[] OverlapHits = new Collider2D[128];
    
    private readonly ICollisionRegistry _collisionRegistry;

    public PhysicsService(ICollisionRegistry collisionRegistry)
    {
      _collisionRegistry = collisionRegistry;
    }

    public IEnumerable<GameEntity> RaycastAll(Vector2 worldPosition, Vector2 direction, int layerMask)
    {
      int hitCount = Physics2D.RaycastNonAlloc(worldPosition, direction, Hits, layerMask);

      for (int i = 0; i < hitCount; i++)
      {
        RaycastHit2D hit = Hits[i];
        if (hit.collider == null)
          continue;

        GameEntity entity = _collisionRegistry.Get<GameEntity>(hit.collider.GetInstanceID());
        if (entity == null)
          continue;

        yield return entity;
      }
    }

    public IEnumerable<GameEntity> OverlapBox(Vector2 center, Vector2 size, float angle, int layerMask)
    {
      int hitCount = Physics2D.OverlapBoxNonAlloc(center, size, angle, OverlapHits, layerMask);

      DrawDebugBox(center, size, angle, 1f, Color.yellow);
      
      for (int i = 0; i < hitCount; i++)
      {
        Collider2D hit = OverlapHits[i];
        if (hit == null)
          continue;

        GameEntity entity = _collisionRegistry.Get<GameEntity>(hit.GetInstanceID());
        if (entity == null)
          continue;

        yield return entity;
      }
    }

    public GameEntity Raycast(Vector2 worldPosition, Vector2 direction, int layerMask)
    {
      int hitCount = Physics2D.RaycastNonAlloc(worldPosition, direction, Hits, layerMask);

      for (int i = 0; i < hitCount; i++)
      {
        RaycastHit2D hit = Hits[i];
        if (hit.collider == null)
          continue;

        GameEntity entity = _collisionRegistry.Get<GameEntity>(hit.collider.GetInstanceID());
        if (entity == null)
          continue;

        return entity;
      }

      return null;
    }

    public GameEntity LineCast(Vector2 start, Vector2 end, int layerMask)
    {
      int hitCount = Physics2D.RaycastNonAlloc(start, end, Hits, layerMask);

      for (int i = 0; i < hitCount; i++)
      {
        RaycastHit2D hit = Hits[i];
        if (hit.collider == null)
          continue;

        GameEntity entity = _collisionRegistry.Get<GameEntity>(hit.collider.GetInstanceID());
        if (entity == null)
          continue;

        return entity;
      }

      return null;
    }
    
    public IEnumerable<GameEntity> CircleCast(Vector3 position, float radius, int layerMask) 
    {
      int hitCount = OverlapCircle(position, radius, OverlapHits, layerMask);

      DrawDebug(position, radius, 1f, Color.red);
      
      for (int i = 0; i < hitCount; i++)
      {
        GameEntity entity = _collisionRegistry.Get<GameEntity>(OverlapHits[i].GetInstanceID());
        if (entity == null)
          continue;

        yield return entity;
      }
    }

    public int CircleCastNonAlloc(Vector3 position, float radius, int layerMask, GameEntity[] hitBuffer) 
    {
      int hitCount = OverlapCircle(position, radius, OverlapHits, layerMask);

      DrawDebug(position, radius, 1f, Color.green);
      
      for (int i = 0; i < hitCount; i++)
      {
        GameEntity entity = _collisionRegistry.Get<GameEntity>(OverlapHits[i].GetInstanceID());
        if (entity == null)
          continue;

        if (i < hitBuffer.Length)
          hitBuffer[i] = entity;
      }

      return hitCount;
    }

    public TEntity OverlapPoint<TEntity>(Vector2 worldPosition, int layerMask) where TEntity : class
    {
      int hitCount = Physics2D.OverlapPointNonAlloc(worldPosition, OverlapHits, layerMask);

      for (int i = 0; i < hitCount; i++)
      {
        Collider2D hit = OverlapHits[i];
        if (hit == null)
          continue;

        TEntity entity = _collisionRegistry.Get<TEntity>(hit.GetInstanceID());
        if (entity == null)
          continue;

        return entity;
      }

      return null;
    }

    public int OverlapCircle(Vector3 worldPos, float radius, Collider2D[] hits, int layerMask) =>
      Physics2D.OverlapCircleNonAlloc(worldPos, radius, hits, layerMask);
    
    private static void DrawDebug(Vector2 worldPos, float radius, float seconds, Color color)
    {
      Debug.DrawRay(worldPos, radius * Vector3.up, color, seconds);
      Debug.DrawRay(worldPos, radius * Vector3.down, color, seconds);
      Debug.DrawRay(worldPos, radius * Vector3.left, color, seconds);
      Debug.DrawRay(worldPos, radius * Vector3.right, color, seconds);
    }
    
    private static void DrawDebugBox(Vector2 center, Vector2 size, float angle, float duration, Color color)
    {
      Vector3 halfSize = size * 0.5f;

      // Вычисление углов прямоугольника с учетом угла поворота
      Vector3[] corners = {
        Rotate(Vector3.left * halfSize.x + Vector3.up * halfSize.y, angle) + (Vector3)center,
        Rotate(Vector3.right * halfSize.x + Vector3.up * halfSize.y, angle) + (Vector3)center,
        Rotate(Vector3.right * halfSize.x + Vector3.down * halfSize.y, angle) + (Vector3)center,
        Rotate(Vector3.left * halfSize.x + Vector3.down * halfSize.y, angle) + (Vector3)center,
      };

      // Отрисовка линий прямоугольника
      Debug.DrawLine(corners[0], corners[1], color, duration);
      Debug.DrawLine(corners[1], corners[2], color, duration);
      Debug.DrawLine(corners[2], corners[3], color, duration);
      Debug.DrawLine(corners[3], corners[0], color, duration);
    }

    private static Vector3 Rotate(Vector3 point, float angle)
    {
      float rad = angle * Mathf.Deg2Rad;
      float cos = Mathf.Cos(rad);
      float sin = Mathf.Sin(rad);
      return new Vector3(
        point.x * cos - point.y * sin,
        point.x * sin + point.y * cos
      );
    }
  }
}