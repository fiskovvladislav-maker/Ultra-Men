using UnityEngine;

public class UltraMenMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _upSpeedMultiplier = 1.5f;
    [SerializeField] private float _downSpeedMultiplier = 0.5f;

    [Header("Links")]
    public Transform UltraMen;

    private SpeedModel _speedModel;
    public void Initialize(SpeedModel model)
    {
        _speedModel = model;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); 
        float vertical = Input.GetAxisRaw("Vertical");    
        float upDown = Input.GetAxisRaw("Fly");          

        Vector3 inputVector = new Vector3(horizontal, upDown, vertical);

        if (inputVector.sqrMagnitude > 1f)
        {
            inputVector.Normalize();
        }

        float horizontalMagnitude = new Vector2(horizontal, vertical).magnitude;
        if (horizontalMagnitude > 1f) horizontalMagnitude = 1f;

        float verticalMagnitude = Mathf.Abs(upDown);

        float verticalSpeed = verticalMagnitude * _moveSpeed;
        if (upDown > 0)
            verticalSpeed *= _upSpeedMultiplier;
        else if (upDown < 0)
            verticalSpeed *= _downSpeedMultiplier;

        float horizontalSpeed = horizontalMagnitude * _moveSpeed;


        Vector3 horizontalMove = new Vector3(horizontal, 0, vertical).normalized;
        UltraMen.Translate(horizontalMove * horizontalSpeed * Time.deltaTime);

        if (upDown != 0)
        {
            Vector3 verticalMove = new Vector3(0, upDown, 0).normalized;
            UltraMen.Translate(verticalMove * verticalSpeed * Time.deltaTime);
        }

        if (_speedModel != null)
        {
            float totalSpeed = horizontalSpeed + verticalSpeed;
            _speedModel.CurrentSpeed = totalSpeed;
        }
    }
}