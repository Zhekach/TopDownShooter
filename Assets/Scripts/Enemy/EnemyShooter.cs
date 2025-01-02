using Unity.XR.OpenVR;
using UnityEngine;

namespace Enemy
{
    public class EnemyShooter : ShooterController
    {
        private GameObject _player;

        public EnemyShooter(GameObject player, GameObject parent,
            GameObject bulletPrefab, GameObject firePoint
        ) : base(bulletPrefab, firePoint, parent)
        {
            _player = player;
        }

        public override void CountFireTimer()
        {
            base.CountFireTimer();

            if (TryAimPlayer())
            {
                Shoot();
            }
        }

        private bool TryAimPlayer()
        {
            RaycastHit2D hit2D = Physics2D.Raycast(_firePoint.transform.position,
                _player.transform.position - _firePoint.transform.position, 100f);

            if (hit2D.collider.transform.gameObject == _player)
                return true;
            
            return false;
        }
    }
}