using UnityEngine;

public abstract class ShooterController
{
    protected GameObject _firePoint;
    private GameObject _bulletPrefab;
    private GameObject _parent;
    
    private float _bulletSpeed;
    private float _fireRate;
    
    private float _nextFire;
    
    public ShooterController(GameObject bulletPrefab, GameObject firePoint, GameObject parent)
    {
        _bulletPrefab = bulletPrefab;
        _firePoint = firePoint;
        _parent = parent;
        _nextFire = _fireRate;
        var bullet = _bulletPrefab.GetComponent<Bullet>();
        _bulletSpeed = bullet.Speed;
        _fireRate = bullet.FireRate;
    }

    public virtual void CountFireTimer()
    {
        if (_nextFire <= 0)
            return;

        _nextFire -= Time.fixedDeltaTime;
    }

    public virtual void Shoot()
    {
        if (_nextFire > 0f)
            return;

        _nextFire = _fireRate;
        
        var bullet = Object.Instantiate(
            _bulletPrefab, _firePoint.transform.position, _parent.transform.rotation);
        
        var direction = new Vector2(
            Mathf.Cos((_parent.transform.eulerAngles.z + 90) * Mathf.Deg2Rad),
            Mathf.Sin((_parent.transform.eulerAngles.z + 90) * Mathf.Deg2Rad));

        bullet.GetComponent<Rigidbody2D>().linearVelocity = direction * _bulletSpeed;
    }
}