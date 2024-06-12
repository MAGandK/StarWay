using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private TMP_Text _countEnemyText;
    [SerializeField] private GameObject[] _playerHearts;
    
    private int _enemyCount = 0;
    private int _playerHealthCount = 3;
    

    private void OnEnable()
    {
        PlayerController.OnTakeDamage += PlayerControllerOnTakeDamage;
        AsteroidTrigger.OnAsteroidDestroyed += AsteroidTriggerOnAsteroidDestroyed;
        EnemyTrigger.OnEnemyDestroyed += EnemyTriggerOnEnemyDestroyed;
    }
    
    private void Start()
    {
        UpdateCountText();
    }

    private void AsteroidTriggerOnAsteroidDestroyed()
    {
        _enemyCount++;
        UpdateCountText();
    }

    private void PlayerControllerOnTakeDamage()
    {
        _playerHealthCount--;
        if (_playerHealthCount >= 0 && _playerHealthCount < _playerHearts.Length)
        {
            _playerHearts[_playerHealthCount].SetActive(false);
        }
    }
    
    private void UpdateCountText()
    {
        _countEnemyText.text = _enemyCount.ToString();
    }
    private void EnemyTriggerOnEnemyDestroyed()
    {
        _enemyCount++;
        UpdateCountText();
    }
    private void OnDisable()
    {
        PlayerController.OnTakeDamage -= PlayerControllerOnTakeDamage;
        AsteroidTrigger.OnAsteroidDestroyed -= AsteroidTriggerOnAsteroidDestroyed;
        EnemyTrigger.OnEnemyDestroyed -= EnemyTriggerOnEnemyDestroyed;
    }
}