using Enemy;
using Player;
using UnityEngine;

namespace Map
{
    public class SpawnController : MonoBehaviour
    {
        [SerializeField] private Spawner _playerSpawner;
        [SerializeField] private Spawner _enemySpawner;
        private GameObject _player;
        private GameObject _enemy;

        private void Start()
        {
            SpawnMap();
        }

        private void OnEnable()
        {
            Bullet.OnBulletHit += RespawnMap;
        }

        private void OnDisable()
        {
            Bullet.OnBulletHit -= RespawnMap;
        }

        private void SpawnMap()
        {
            _player = _playerSpawner.Spawn();
            _enemy = _enemySpawner.Spawn();
            
            var playerController = _player.GetComponent<PlayerController>();
            playerController.Initialize();
            
            var enemyController = _enemy.GetComponent<EnemyController>();
            enemyController.Initialize(_player);
        }

        private void RespawnMap(Bullet bullet = null)
        {
            _player.transform.position = _playerSpawner.transform.position;
            _enemy.transform.position = _enemySpawner.transform.position;
        }
    }
}