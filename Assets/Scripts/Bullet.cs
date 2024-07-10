using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody;
    
    private Pool<Bullet> _pool;

    public void Init(Pool<Bullet> pool)
    {
        _pool = pool;
    }
    
    private void FixedUpdate()
    {
        _rigidbody.AddForce(transform.up * _speed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _pool.Disable(this);
    }
}
