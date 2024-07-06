using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector2 _direction;
    
    private void Update()
    {
        _direction = transform.up * (_speed * Time.deltaTime);
        transform.Translate(_direction, Space.World);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // сделать выключение с пула
        Destroy(gameObject);
    }
}
