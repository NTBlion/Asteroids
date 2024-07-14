using System;
using UnityEngine;

public class UFO : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Player _player;

    public void Init(Player player)
    {
        _player = player;
        _player.Destroyed += OnDestroyed;
    }
    
    private void OnDisable()
    {
        _player.Destroyed -= OnDestroyed;
    }

    private void Update()
    {
        transform.Translate((_player.transform.position - transform.position).normalized * (_speed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.TryGetComponent(out Health health))
            health.TakeDamage();
        
        Destroy(gameObject);
    }

    private void OnDestroyed()
    {
        Destroy(gameObject);
    }
    
}