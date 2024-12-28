using UnityEngine;

namespace Enemy
{
    public class EnemyMovement
    {
        private GameObject _player;
        private Rigidbody2D _rigidbody;
        private Transform _transform;
        
        private float _speed;

        public EnemyMovement(GameObject player, GameObject enemy, float speed)
        {
            _player = player;
            _rigidbody = enemy.GetComponent<Rigidbody2D>();
            _transform = enemy.transform;
            _speed = speed;
        }

        public void MoveToPlayer()
        {
            var direction = (_player.transform.position - _transform.position).normalized;
            _rigidbody.linearVelocity = direction * _speed;
            
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _rigidbody.rotation = angle - 90f;
        }
    }
}