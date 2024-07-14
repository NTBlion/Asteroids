using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Sprite[] _sprites;

    private void OnEnable()
    {
        _renderer.sprite = _sprites[Random.Range(0, _sprites.Length)];
    }
}
