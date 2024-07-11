using UnityEngine;

public class Movement : MonoBehaviour
{
    private const string Horizontal = "Horizontal";

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
            _rigidbody.AddForce(transform.up * _speed, ForceMode2D.Impulse);
    }

    private void Update()
    {
        Vector3 direction = new Vector3(0, 0, Input.GetAxis(Horizontal));

        transform.Rotate(-direction * (Time.deltaTime * _rotationSpeed));
    }
}