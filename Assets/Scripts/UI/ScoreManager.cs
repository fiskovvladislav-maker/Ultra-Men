using UnityEngine;
using TMPro; 

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText; 

    private int _killCount = 0;

    private void Start()
    {
       
        UpdateText();
    }

    private void OnEnable()
    {
        Enemy.OnEnemyDied += AddKill;
    }

    private void OnDisable()
    {
        Enemy.OnEnemyDied -= AddKill;
    }

    private void AddKill()
    {
        _killCount++;
        UpdateText();
    }

    private void UpdateText()
    {
        if (_scoreText != null)
        {
            _scoreText.text = $"Kills: {_killCount}";
        }
    }
}