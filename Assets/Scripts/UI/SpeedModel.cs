using System;
using UnityEngine;

public class SpeedModel
{
    public event Action<float> OnSpeedChanged;

    private float _currentSpeed;

    public float CurrentSpeed
    {
        get => _currentSpeed;
        set
        {
            if (Math.Abs(_currentSpeed - value) > 0.01f)
            {
                _currentSpeed = value;
                OnSpeedChanged?.Invoke(_currentSpeed);
            }
        }
    }
}
