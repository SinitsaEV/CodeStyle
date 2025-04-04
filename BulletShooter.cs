using System.Collections;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private Vector3 _direction;

    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _bulletSpeed;

    [SerializeField] private float _delay;
    [SerializeField] private bool _isWork = true;
    private WaitForSeconds _shootDelay;

    private void Awake()
    {
        _shootDelay = new WaitForSeconds(_delay);        
    }

    private void Start()
    {        
        StartCoroutine(ShootCoroutine());
    }

    private IEnumerator ShootCoroutine()
    {
        while (_isWork)
        {
            _direction = (_target.position - transform.position).normalized;
            Bullet newBullet = Instantiate(_bulletPrefab, transform.position, Quaternion.LookRotation(_direction));
            newBullet.GetComponent<Rigidbody>().velocity = _direction * _bulletSpeed;

            yield return _shootDelay;
        }
    }
}