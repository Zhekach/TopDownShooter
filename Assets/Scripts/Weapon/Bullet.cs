using System;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
       public string ShooterTag { get; private set; }
       public string HitTag { get; private set; }
       
       private int _maxRicochets = 2;
       
       public static Action<Bullet, string > OnBulletHit;
       
       public Bullet(string shooterTag)
       {
           ShooterTag = shooterTag;
       }

       public void OnCollisionEnter2D(Collision2D other)
       {
           HitTag = "ad";
       }
}
