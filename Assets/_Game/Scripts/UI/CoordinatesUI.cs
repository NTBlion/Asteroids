using System;
using TMPro;
using UnityEngine;

public class CoordinatesUI : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _player.Destroyed += OnDestroyed;
    }

    private void OnDisable()
    {
        _player.Destroyed -= OnDestroyed;
    }

    private void OnDestroyed()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        Vector3 position = _player.transform.position;
        _text.text = $"X: {position.x:F2} Y: {position.y:F2}";
    }
}