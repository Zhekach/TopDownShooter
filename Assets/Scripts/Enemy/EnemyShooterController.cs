using UnityEngine;

namespace Enemy
{
    public class EnemyShooterController : ShooterController
    {
        private Rigidbody2D _rigidbody;
        
        protected override void Update() {}

        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            if (TryAimPlayer())
            {
                Shoot();
            }
        }

        private bool TryAimPlayer()
        {
            // var direction = (_player.transform.position - transform.position).normalized;
            // _rigidbody.linearVelocity = direction * _speed;
            //
            // float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            // _rigidbody.rotation = angle - 90f;
            //
            
            //if(Physics2D.RaycastAll(transform.position, ))
            return true;
        }
    }
}