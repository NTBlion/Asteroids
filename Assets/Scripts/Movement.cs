using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    private bool _thrusting;
    private bool _rotating;
    private Vector3 _direction;

    private void Awake()
    {
        _direction = new Vector3(0, 0, 1);
    }
    
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
            _rigidbody.AddForce(transform.up * _speed, ForceMode2D.Impulse);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(_direction * (Time.deltaTime * _rotationSpeed)) ;
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(-_direction * (Time.deltaTime * _rotationSpeed));
    }
}