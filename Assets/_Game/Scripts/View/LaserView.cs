using _Game.Scripts.Shooting;
using UnityEngine;

namespace _Game.Scripts.View
{
    public class LaserView : MonoBehaviour
    {
        [SerializeField] private Laser _laser;
        [SerializeField] private SpriteRenderer _renderer;

        private void Awake()
        {
            _renderer.enabled = false;
        }

        private void OnEnable()
        {
            _laser.Enabled += OnEnabled;
            _laser.Disabled += OnDisabled;
        }

        private void OnDisable()
        {
            _laser.Enabled -= OnEnabled;
            _laser.Disabled -= OnDisabled;
        }

        private void OnDisabled()
        {
            _renderer.enabled = false;
        }

        private void OnEnabled()
        {
            _renderer.enabled = true;
        }
    }
}