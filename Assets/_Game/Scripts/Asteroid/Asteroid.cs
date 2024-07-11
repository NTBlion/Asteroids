using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _minForce;
    [SerializeField] private float _maxForce;
    [SerializeField] private int _damage = 1;

    public Action<Asteroid> Splitted;

    private Pool<Asteroid> _pool;

    public void Init(Pool<Asteroid> pool)
    {
        _pool = pool;
    }

    private void OnEnable()
    {
        _rigidbody.AddForce(new Vector2(Random.Range(_minForce, _maxForce), Random.Range(_minForce, _maxForce)),
            ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.TryGetComponent(out Health health))
        {
            health.TakeDamage(_damage);
        }

        Splitted?.Invoke(this);
        _pool.Disable(this);
    }
}