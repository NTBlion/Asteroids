using System;
using TMPro;
using UnityEngine;

public class CoordinatesUI : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private TMP_Text _coordinatesText;

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
        float rotationZ = _player.transform.rotation.z;
        Vector3 position = _player.transform.position;
        float speed = _rigidbody.velocity.magnitude;
        _coordinatesText.text = $"X: {position.x:F2} Y: {position.y:F2} Rotation: {rotationZ:F2}\u00b0 Speed: {speed:F2} units/sec";
    }
}