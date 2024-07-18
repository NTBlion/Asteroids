using _Game.Scripts.Character;
using TMPro;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.UI
{
    public class CoordinatesUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _coordinatesText;

        private Movement _movement;
        private Player _player;
        private Rigidbody2D _rigidbody;

        [Inject]
        private void Construct(Movement movement, Player player)
        {
            _movement = movement;
            _player = player;
            _rigidbody = _movement.GetComponent<Rigidbody2D>();
        }
        
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
            float rotationZ = _movement.transform.rotation.z;
            Vector3 position = _movement.transform.position;
            float speed = _rigidbody.velocity.magnitude;
            _coordinatesText.text =
                $"X: {position.x:F2} Y: {position.y:F2} Rotation: {rotationZ:F2}\u00b0 Speed: {speed:F2} units/sec";
        }
    }
}