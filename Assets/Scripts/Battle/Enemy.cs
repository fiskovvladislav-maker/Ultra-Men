using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [Header("Movement")]
    [SerializeField] private float _moveSpeed = 10f;       
    [SerializeField] private float _rotationSpeed = 5f;
    [SerializeField] private float _preferredDistance = 30f;
    [SerializeField] private float _distanceTolerance = 5f;  

    [Header("Combat")]
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _fireRate = 1f;
    [SerializeField] private float _health = 20f;

    private Transform _player;
    private float _nextFireTime;
    private Vector3 _strafeDirection;

    public static event System.Action OnEnemyDied;

    private void OnEnable()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            _player = playerObj.transform;

        
        _strafeDirection = (Random.value > 0.5f) ? Vector3.right : Vector3.left;
    }

    private void Update()
    {
        if (_player == null) return;

        Vector3 lookDirection = _player.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);


        float distanceToPlayer = Vector3.Distance(transform.position, _player.position);

        Vector3 moveDirection = Vector3.zero;

        if (distanceToPlayer > _preferredDistance + _distanceTolerance)
        {
            moveDirection = transform.forward;
        }
        else if (distanceToPlayer < _preferredDistance - _distanceTolerance)
        {
            moveDirection = -transform.forward;
        }
        else
        {
            moveDirection = (transform.right * _strafeDirection.x).normalized;
        }

        transform.Translate(moveDirection * _moveSpeed * Time.deltaTime, Space.World);


        if (Time.time >= _nextFireTime)
        {
            Shoot();
            _nextFireTime = Time.time + 1f / _fireRate;
        }
    }

    private void Shoot()
    {
        if (_firePoint != null)
            ObjectPool.Instance.SpawnFromPool("Bullet", _firePoint.position, _firePoint.rotation);
    }

    public void TakeDamage(float damage)
    {
        Debug.Log($"Враг получил {damage} урона. HP: {_health - damage}");
        _health -= damage;
        if (_health <= 0)
        {
            Debug.Log("Враг умер и возвращается в пул.");
            OnEnemyDied?.Invoke();
            gameObject.SetActive(false);
        }
    }
}