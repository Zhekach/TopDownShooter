using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private GameObject _firePoint;
        
        [SerializeField] private float _movementSpeed = 5f;
        
        private PlayerMovement _movement;
        private PlayerShooter _shooter;

        public void Initialize()
        {
            _movement = new PlayerMovement(gameObject, _movementSpeed);
            _shooter = new PlayerShooter(gameObject, _bulletPrefab, _firePoint);
        }

        private void Update()
        {
            _movement.RotateTowardsMouse();
        }
        
        private void FixedUpdate()
        {
            _movement.MoveCharacter();
            _shooter.Shoot();
        }
    }
}