using UnityEngine;

public class SpeedPresenter : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpeedView _view;
    [SerializeField] private UltraMenMovement _movement;

    private SpeedModel _model;

    private void Start()
    {
        _model = new SpeedModel();

        _model.OnSpeedChanged += _view.UpdateSpeedText;

        if (_movement == null)
            _movement = FindAnyObjectByType<UltraMenMovement>();

        if (_movement != null)
            _movement.Initialize(_model);
    }

    private void OnDestroy()
    {
        if (_model != null)
            _model.OnSpeedChanged -= _view.UpdateSpeedText;
    }
}