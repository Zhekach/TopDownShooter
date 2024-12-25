using UnityEngine;

public abstract class ShooterController : MonoBehaviour
{
    public float bulletSpeed = 20f;
    public GameObject bulletPrefab;
    
    protected abstract void Update();

    protected void Shoot()
    {
        var bullet = Instantiate(bulletPrefab);
        bullet.transform.parent = null;
        bullet.GetComponent<Rigidbody2D>().linearVelocity = transform.position * bulletSpeed;
        Destroy(bullet, 5f);
    }
}