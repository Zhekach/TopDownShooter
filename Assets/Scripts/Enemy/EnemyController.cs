using UnityEngine;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private float _speed = 5f;

        private EnemyMovement _movement;
        
        public void Initialize(GameObject player)
        {
            _player = player;
            _movement = new EnemyMovement(_player, gameObject, _speed);
        }

        private void FixedUpdate()
        {
            _movement.MoveToPlayer();
        }
    }
}