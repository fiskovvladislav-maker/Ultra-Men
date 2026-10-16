using UnityEngine;
using TMPro; 

public class SpeedView : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI _speedText;

    [Tooltip("Формат отображения. {0} заменится на число")]
    [SerializeField] private string _format = "Скорость: {0:0} м/с";

    public void UpdateSpeedText(float speed)
    {
        if (_speedText != null)
        {
            _speedText.text = string.Format(_format, speed);
        }
    }
}