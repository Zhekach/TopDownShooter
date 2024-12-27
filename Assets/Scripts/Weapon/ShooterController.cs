using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class ShooterController : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _firePoint;
    
    [SerializeField] private float _bulletSpeed = 20f;
    [SerializeField] private float _fireRate = 0.1f;

    private float _nextFire;

    private void Awake()
    {
        _nextFire = _fireRate;
    }

    protected abstract void Update();

    protected virtual void FixedUpdate()
    {
        CountFireTimer();
    }

    protected void Shoot()
    {
        if (_nextFire > 0f)
            return;

        _nextFire = _fireRate;
        var bullet = Instantiate(_bulletPrefab, _firePoint.transform.position, transform.rotation);
        Vector2 direction = new Vector2(
            Mathf.Cos((transform.eulerAngles.z + 90) * Mathf.Deg2Rad),
            Mathf.Sin((transform.eulerAngles.z + 90) * Mathf.Deg2Rad));

        bullet.GetComponent<Rigidbody2D>().linearVelocity = direction * _bulletSpeed;
        // bullet.GetComponent<Rigidbody2D>().linearVelocity = transform.position.normalized * bulletSpeed;

        Destroy(bullet, 5f);
    }

    private void CountFireTimer()
    {
        if (_nextFire == 0)
            return;

        _nextFire -= Time.fixedDeltaTime;

        if (_nextFire < 0)
            _nextFire = 0;
    }
}