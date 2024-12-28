using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Bullet : MonoBehaviour
{
    public BulletBrokerType DestinationType { get; private set; }

    [FormerlySerializedAs("_bulletSpeed")] [SerializeField] private float _speed;
    [SerializeField] private float _fireRate;
    private int _maxRicochets = 2;
    
    public float Speed => _speed;
    public float FireRate => _fireRate;

    public static event Action<Bullet> OnBulletHit;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case nameof(BulletBrokerType.Player):
                HandleHit(BulletBrokerType.Player);
                break;
            case nameof(BulletBrokerType.Enemy):
                HandleHit(BulletBrokerType.Enemy);
                break;
            case nameof(BulletBrokerType.Barrier):
                HandleRicochet(collision);
                break;
        }
    }

    private void HandleHit(BulletBrokerType bulletBrokerType)
    {
        DestinationType = bulletBrokerType;
        OnBulletHit?.Invoke(this);
    }

    private void HandleRicochet(Collision2D collision)
    {
        if (_maxRicochets <= 0)
            return;

        _maxRicochets--;

        var rigidbody = GetComponent<Rigidbody2D>();
        var direction = rigidbody.linearVelocity;
        var normal = collision.GetContact(0).normal;
        var newDirection = Vector2.Reflect(direction, normal);

        rigidbody.linearVelocity = newDirection;
    }
}

public enum BulletBrokerType
{
    Player,
    Enemy,
    Barrier
}