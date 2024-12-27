using System;
using Enemy;
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
            Bullet.OnBulletHit += SpawnMap;
        }

        private void OnDisable()
        {
            Bullet.OnBulletHit -= SpawnMap;
        }

        private void SpawnMap(Bullet bullet = null)
        {
            _player = _playerSpawner.Spawn();
            _enemy = _enemySpawner.Spawn();
            
            var enemyMovementController = _enemy.GetComponent<EnemyMovementController>();
            enemyMovementController.SetPlayer(_player);
        }
    }
}