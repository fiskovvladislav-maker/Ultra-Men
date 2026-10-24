using UnityEngine;

public class UltraMenMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _moveSpeed = 10f;

    [Tooltip("Множитель скорости при подъеме вверх (Space)")]
    [SerializeField] private float _upSpeedMultiplier = 1.5f;

    [Tooltip("Множитель скорости при полете вниз (Left Shift)")]
    [SerializeField] private float _downSpeedMultiplier = 0.5f;

    [Header("Links")]
    public Transform UltraMen;

    void Update()
    {
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        float upDown = Input.GetAxisRaw("Fly");

        
        Vector3 horizontalMove = new Vector3(horizontal, 0, vertical).normalized;
        UltraMen.Translate(horizontalMove * _moveSpeed * Time.deltaTime);

        
        if (upDown != 0)
        {

            float currentVerticalSpeed;

            if (upDown > 0) 
            {
                currentVerticalSpeed = _moveSpeed * _upSpeedMultiplier;
            }
            else
            {
                currentVerticalSpeed = _moveSpeed * _downSpeedMultiplier;
            }

            Vector3 verticalMove = new Vector3(0, upDown, 0);
            UltraMen.Translate(verticalMove * currentVerticalSpeed * Time.deltaTime);
        }
    }
}