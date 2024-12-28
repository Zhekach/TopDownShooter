using UnityEngine;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private GameObject _firePoint;
        
        [SerializeField] private float _speed = 5f;

        private EnemyMovement _movement;
        private EnemyShooter _shooter;
        
        public void Initialize(GameObject player)
        {
            _player = player;
            _movement = new EnemyMovement(_player, gameObject, _speed);
            _shooter = new EnemyShooter(_player, gameObject, _bulletPrefab, _firePoint);
        }

        private void FixedUpdate()
        {
            _movement.MoveToPlayer();
            _shooter.CountFireTimer();
        }
    }
}