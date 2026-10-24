using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _speed = 100f;    
    [SerializeField] private float _damage = 10f;    
    [SerializeField] private float _lifeTime = 3f;   

    private void OnEnable()
    {
        Invoke(nameof(ReturnToPool), _lifeTime);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(_damage);
        }

        ReturnToPool();
    }

    private void ReturnToPool()
    {
        gameObject.SetActive(false); 
    }
}