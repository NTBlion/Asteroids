using _Game.Scripts.Shooting;
using TMPro;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.UI
{
    public class LaserUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _laserCountText;
        [SerializeField] private TMP_Text _timeBeforeLaserSpawn;

        private Laser _laser;
        private int _shootCount;

        [Inject]
        private void Construct(Laser laser)
        {
            _laser = laser;
        }
        
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
}