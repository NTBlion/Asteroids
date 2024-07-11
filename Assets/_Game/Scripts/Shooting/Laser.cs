using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    [SerializeField] private int _maxShootCount;
    [SerializeField] private float _timeBeforeAddShootCount;
    [SerializeField] private BoxCollider2D _collider;

    public Action Enabled;
    public Action Disabled;
    public Action<int> ShootCountChanged;

    private int _shootCount;
    private float _currentTime;
    private bool _isActive;

    public bool IsActive => _isActive;

    public float TimeBeforeAddShootCount => _timeBeforeAddShootCount;

    private void Awake()
    {
        _shootCount = _maxShootCount;
        ShootCountChanged?.Invoke(_shootCount);
        _collider.enabled = false;
        _currentTime = TimeBeforeAddShootCount;
    }

    private void Update()
    {
        if (_shootCount >= _maxShootCount)
        {
            _shootCount = _maxShootCount;
            ShootCountChanged?.Invoke(_shootCount);
        }
        else
        {
            _timeBeforeAddShootCount -= Time.deltaTime;

            if (_timeBeforeAddShootCount <= 0)
            {
                _shootCount++;
                ShootCountChanged?.Invoke(_shootCount);
                _timeBeforeAddShootCount = _currentTime;
            }
        }
    }

    public IEnumerator ActivateLaser()
    {
        if (_shootCount != 0)
        {
            Enabled?.Invoke();
            _shootCount--;
            ShootCountChanged?.Invoke(_shootCount);
            _collider.enabled = true;
            _isActive = true;
            yield return new WaitForSeconds(_lifeTime);
            Disabled?.Invoke();
            _collider.enabled = false;
            _isActive = false;
        }
    }
}