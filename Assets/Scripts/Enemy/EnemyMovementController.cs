using UnityEngine;

namespace Enemy
{
    public class EnemyMovementController : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        private GameObject _player;
        private Rigidbody2D _rigidbody;
        
        public void SetPlayer(GameObject player) => _player = player;
        
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            MoveToPlayer();
        }

        private void MoveToPlayer()
        {
            var direction = (_player.transform.position - transform.position).normalized;
            _rigidbody.linearVelocity = direction * _speed;
            
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _rigidbody.rotation = angle - 90f;
        }
    }
}