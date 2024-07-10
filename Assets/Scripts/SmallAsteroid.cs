using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAsteroid : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _minForce;
    [SerializeField] private float _maxForce;

    private Pool<SmallAsteroid> _pool;

    public void Init(Pool<SmallAsteroid> pool)
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
        _pool.Disable(this);
    }
}