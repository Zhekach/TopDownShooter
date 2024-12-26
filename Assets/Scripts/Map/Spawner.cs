using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    private GameObject _gameObject;

    private void Awake()
    {
        Spawn();
    }

    public void Respawn()
    {
        Destroy(_gameObject);
        Spawn();
    }

    private void Spawn()
    {
        if (_prefab != null)
        {
            _gameObject = Instantiate(_prefab);
            _gameObject.transform.position = transform.position;
        }
        else
        {
            Debug.LogError("No prefab set on spawner.");
        }
    }
}
