using _Game.Scripts.Shooting;
using UnityEngine;

namespace _Game.Scripts.Character
{
    public class PlayerController : MonoBehaviour
    {
        private Movement _movement;
        private Laser _laser;
        private BulletSpawner _bulletSpawner;
        private PlayerInput _input;

        private bool _canShoot;
        private bool _canMove;
        private bool _canUseLaser;

        public void Init(Movement movement, Laser laser, BulletSpawner bulletSpawner, PlayerInput input)
        {
            _movement = movement;
            _laser = laser;
            _bulletSpawner = bulletSpawner;
            _input = input;
        }

        private void Update()
        {
            if (_input.IsShooting && _canShoot)
                _bulletSpawner.Spawn();

            if (_input.CanUseLaser && _laser.IsActive == false && _canUseLaser)
                StartCoroutine(_laser.ActivateLaser());

            if (_canMove)
                _movement.Rotate(_input.Direction);
        }

        private void FixedUpdate()
        {
            if (_input.IsMoving && _canMove)
                _movement.Move();
        }

        public void DisableShooting() => _canShoot = false;
        public void DisableMoving() => _canMove = false;
        public void DisableLaser() => _canUseLaser = false;

        public void EnableShooting() => _canShoot = true;
        public void EnableMoving() => _canMove = true;
        public void EnableLaser() => _canUseLaser = true;
    }
}