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
            return true;
        }
    }
}