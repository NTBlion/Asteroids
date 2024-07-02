using UnityEngine;

public class Wrap : MonoBehaviour
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Vector3 viewportPosition = _camera.WorldToViewportPoint(transform.position);

        Vector3 moveAdjustment = Vector3.zero;

        switch (viewportPosition.x)
        {
            case < 0:
                moveAdjustment.x += 1;
                break;
            case > 1:
                moveAdjustment.x -= 1;
                break;
        }

        switch (viewportPosition.y)
        {
            case < 0:
                moveAdjustment.y += 1;
                break;
            case > 1:
                moveAdjustment.y -= 1;
                break;
        }

        transform.position = _camera.ViewportToWorldPoint(viewportPosition + moveAdjustment);
    }
}