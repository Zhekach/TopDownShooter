using System;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletBrokerType SourceType { get; private set; }
    public BulletBrokerType DestinationType { get; private set; }

    private int _maxRicochets = 2;

    public static event Action<Bullet> OnBulletHit;

    public Bullet(BulletBrokerType sourceType)
    {
        SourceType = sourceType;
        DestinationType = BulletBrokerType.Empty;
    }
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case nameof(BulletBrokerType.Player):
                HandleHit(BulletBrokerType.Player);
                break;            
            case nameof(BulletBrokerType.Enemy):
                HandleHit(BulletBrokerType.Enemy);
                break;
            case nameof(BulletBrokerType.Barrier):
                HandleRicochet();
                break;
        }
    }

    private void HandleHit(BulletBrokerType bulletBrokerType)
    {
        DestinationType = bulletBrokerType;
        OnBulletHit?.Invoke(this); 
    }
    
    private void HandleRicochet()
    {
        
    }
}

public enum BulletBrokerType
{
    Empty,
    Player,
    Enemy,
    Barrier
}