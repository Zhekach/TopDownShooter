using UnityEngine;

namespace Enemy
{
    public class EnemyMovementController : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        
        public void SetPlayer(GameObject player) => _player = player;
    }
}