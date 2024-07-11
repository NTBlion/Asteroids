using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LaserUI : MonoBehaviour
{
    [SerializeField] private Laser _laser;
    [SerializeField] private TMP_Text _laserCountText;
    [SerializeField] private TMP_Text _timeBeforeLaserSpawn;

    private int _shootCount;
    
    private void OnEnable()
    {
        _laser.ShootCountChanged += OnChanged;
    }
    
    private void OnDisable()
    {
        _laser.ShootCountChanged -= OnChanged;
    }

    private void Update()
    {
        _timeBeforeLaserSpawn.text = $"Time: {_laser.TimeBeforeAddShootCount:F1}";
}

    private void OnChanged(int shootCount)
    {
        _shootCount = shootCount;
        _laserCountText.text = "Lasers: " + _shootCount.ToString();
    }
}
