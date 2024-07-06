using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : Pool
{
    [SerializeField] private BoxCollider2D _spawnZone;

    public void Spawn(int spawnCount)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            var asteroid = EnableObject();

            var bound = _spawnZone.bounds;
            var positionX = Random.Range(bound.min.x, bound.max.x);
            var positionY = Random.Range(bound.min.y, bound.max.y);

            _spawnZone.transform.position = new Vector2(positionX, positionY);
            asteroid.transform.position = _spawnZone.transform.position;
        }
    }
}