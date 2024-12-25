using TMPro;
using UnityEngine;

public class GameScoreController : MonoBehaviour
{
    [SerializeField] private TMP_Text _playerScoreText;
    [SerializeField] private TMP_Text _enemyScoreText;
    
    [SerializeField] private int _scoresPerKill = 10;
    [SerializeField] private int _scoresPerFriendlyFire = 10;
    
    private int _playerScore = 0;
    private int _enemyScore = 0;
    
    public void AddPlayerScore(int scoreValue)
    {
        _playerScore += scoreValue;
        _playerScoreText.text = _playerScore.ToString();
    }
    
    public void AddEnemyScore(int scoreValue)
    {
        _enemyScore += scoreValue;
        _enemyScoreText.text = _enemyScore.ToString();
    }
    
}