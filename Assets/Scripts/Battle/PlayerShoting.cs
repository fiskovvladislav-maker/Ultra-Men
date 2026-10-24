using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _fireRate = 0.2f; 
    [SerializeField] private Transform _firePoint;   

    private float _nextFireTime;

    private void Update()
    {
        
        if (Input.GetMouseButton(0) && Time.time >= _nextFireTime)
        {
            Shoot();
            _nextFireTime = Time.time + _fireRate;
        }
    }

    private void Shoot()
    {
        
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

       
        Vector3 targetPoint = ray.origin + ray.direction * 100f;

        
        Vector3 spawnPos = (_firePoint != null) ? _firePoint.position : transform.position;

       
        Vector3 shootDirection = (targetPoint - spawnPos).normalized;

       
        Quaternion spawnRotation = Quaternion.LookRotation(shootDirection);

      
        ObjectPool.Instance.SpawnFromPool("Bullet", spawnPos, spawnRotation);
    }
}