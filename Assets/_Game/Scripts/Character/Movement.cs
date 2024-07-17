using UnityEngine;

namespace _Game.Scripts.Character
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed;
    
        public void Rotate(Vector3 direction)
        {
            transform.Rotate(-direction * (Time.deltaTime * _rotationSpeed));
        }

        public void Move()
        {
            _rigidbody.AddForce(transform.up * _speed, ForceMode2D.Impulse);
        }
    }
}