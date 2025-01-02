using UnityEngine;

namespace Player
{
    public class PlayerMovement
    {
        private Rigidbody2D _rigidbody;
        private Transform _transform;
        private Camera _camera;
        
        private float _speed;

        public PlayerMovement(GameObject parent, float speed)
        {
            _rigidbody = parent.GetComponent<Rigidbody2D>();
            _transform = parent.transform;
            _speed = speed;
            _camera = Camera.main;
        }

        public void MoveCharacter()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            
            Vector2 movement = new Vector2(horizontal, vertical).normalized;
            
            if (movement.magnitude > 0.9f)
            {
                _rigidbody.linearVelocity = movement * _speed;
            }
            else
            {
                _rigidbody.linearVelocity = Vector2.zero;
            }
            
        }

        public void RotateTowardsMouse()
        {
            Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePosition - _transform.position).normalized;


            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _rigidbody.rotation = angle - 90f;
        }
    }
}
