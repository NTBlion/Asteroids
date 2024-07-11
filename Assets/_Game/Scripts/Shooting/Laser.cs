using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    [SerializeField] private int _maxShootCount;
    [SerializeField] private float _timeBeforeAddShootCount;
    [SerializeField] private BoxCollider2D _collider;

    public Action Enabled;
    public Action Disabled;

    private int _shootCount;
    private float _time = 0;
    private bool _isActive;

    private void Awake()
    {
        _shootCount = _maxShootCount;
        _collider.enabled = false;
    }

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time > _timeBeforeAddShootCount)
        {
            _shootCount++;

            if (_shootCount >= _maxShootCount)
                _shootCount = _maxShootCount;

            _time = 0;
        }
    }

    public bool IsActive => _isActive;

    public IEnumerator ActivateLaser()
    {
        if (_shootCount != 0)
        {
            Enabled?.Invoke();
            _shootCount--;
            _collider.enabled = true;
            _isActive = true;
            yield return new WaitForSeconds(_lifeTime);
            Disabled?.Invoke();
            _collider.enabled = false;
            _isActive = false;
        }
    }
}