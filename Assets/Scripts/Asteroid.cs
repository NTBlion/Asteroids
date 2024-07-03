using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _minForce;
    [SerializeField] private float _maxForce;
    
    private void OnEnable()
    {
        _rigidbody.AddForce(new Vector2(Random.Range(_minForce,_maxForce), Random.Range(_minForce,_maxForce)), ForceMode2D.Impulse);
    }
    
}
