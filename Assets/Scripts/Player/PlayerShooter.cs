using UnityEngine;

namespace Player
{
    public class PlayerShooter : ShooterController
    {
        
        public PlayerShooter(GameObject parent,
            GameObject bulletPrefab, GameObject firePoint 
        ) : base(parent, bulletPrefab, firePoint){}
        
        public override void Shoot()
        {
            if (Mathf.Approximately(Input.GetAxis("Fire1"), 1))
            {
                base.Shoot();
            }
        }
    }
}