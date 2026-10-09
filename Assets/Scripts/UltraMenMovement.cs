using UnityEngine;
using System.Collections.Generic;

public class FlyerMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _moveSpeed = 10f;

    void Start()
    {

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

        
        Vector3 moveDirection = new Vector3(horizontal, upDown, vertical);

       
        if (moveDirection.sqrMagnitude > 1f)
        {
            moveDirection.Normalize();
        }

        transform.Translate(moveDirection * _moveSpeed * Time.deltaTime);
    }
}