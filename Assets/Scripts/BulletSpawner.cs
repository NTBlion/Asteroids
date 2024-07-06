using UnityEngine;

public class BulletSpawner : Pool
{
    [SerializeField] private Transform _spawnPoint;


    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
            Spawn();
    }

    public void Spawn()
    {
        var bullet = EnableObject();
        bullet.transform.position = _spawnPoint.position;
    }
}