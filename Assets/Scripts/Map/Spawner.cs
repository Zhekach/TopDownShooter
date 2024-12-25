using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    void Awake()
    {
        if (_prefab != null)
        {
            Instantiate(_prefab);
        }
        else
        {
            Debug.LogError("No prefab set on spawner.");
        }
    }
}
