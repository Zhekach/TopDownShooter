using UnityEngine;

namespace Player
{
    public class PlayerShootingController : ShooterController
    {
        protected override void Update()
        {
            if (Mathf.Approximately(Input.GetAxis("Fire1"), 1))
            {
                Shoot();
            }
        }
    }
}