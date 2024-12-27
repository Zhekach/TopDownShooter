using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    private GameObject _gameObject;

    public GameObject Spawn()
    {
        if (_prefab != null)
        {
            if (_gameObject != null)
            {
                Destroy(_gameObject);
            }
            
            _gameObject = Instantiate(_prefab);
            _gameObject.transform.position = transform.position;
            
            return _gameObject;
        }

        Debug.LogError("No prefab set on spawner.");
        return null;
    }
}
