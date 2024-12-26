using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScoreController : MonoBehaviour
{
    [SerializeField] private Spawner _playerSpawner;
    [SerializeField] private Spawner _enemySpawner;
        
    [SerializeField] private TMP_Text _playerScoreText;
    [SerializeField] private TMP_Text _enemyScoreText;
    
    [SerializeField] private int _scoresPerKill = 10;
    
    private int _playerScore;
    private int _enemyScore;

    private void Awake()
    {
        _playerScoreText.text = _playerScore.ToString();
        _enemyScoreText.text = _enemyScore.ToString();
    }
    
    private void OnEnable()
    {
        Bullet.OnBulletHit += BulletHitHandler;
    }

    private void OnDisable()
    {
        Bullet.OnBulletHit -= BulletHitHandler;
    }

    private void BulletHitHandler(Bullet bullet)
    {
        if (bullet.DestinationType == BulletBrokerType.Enemy)
        {
            AddPlayerScore(_scoresPerKill);
        }
        else
        {
           AddEnemyScore(_scoresPerKill); 
        }
        
        Destroy(bullet.gameObject);
        
        RespawnMap();
    }

    private void AddPlayerScore(int scoreValue)
    {
        _playerScore += scoreValue;
        _playerScoreText.text = _playerScore.ToString();
    }

    private void AddEnemyScore(int scoreValue)
    {
        _enemyScore += scoreValue;
        _enemyScoreText.text = _enemyScore.ToString();
    }

    private void RespawnMap()
    {
        _playerSpawner.Respawn();
        _enemySpawner.Respawn();
    }
}