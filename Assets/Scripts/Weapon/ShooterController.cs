using UnityEngine;

public abstract class ShooterController
{
    private GameObject _bulletPrefab;
    private GameObject _firePoint;
    private GameObject _parent;
    
    private float _bulletSpeed = 20f;
    private float _fireRate = 0.1f;

    private float _nextFire;
    
    public ShooterController(GameObject bulletPrefab, GameObject firePoint, GameObject parent)
    {
        _bulletPrefab = bulletPrefab;
        _firePoint = firePoint;
        _parent = parent;
    }

    private void Awake()
    {
        _nextFire = _fireRate;
    }

    public virtual void CountFireTimer()
    {
        if (_nextFire == 0)
            return;

        _nextFire -= Time.fixedDeltaTime;

        if (_nextFire < 0)
            _nextFire = 0;
    }

    protected void Shoot()
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

        Object.Destroy(bullet, 5f);
    }
}