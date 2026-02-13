using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _speed;
    [SerializeField] private float _shootDelay;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        var wait = new WaitForSeconds(_shootDelay);

        while (enabled)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            GameObject bullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);
            Rigidbody rigidbodyBullet = bullet.GetComponent<Rigidbody>();
            
            rigidbodyBullet.transform.up = direction;
            rigidbodyBullet.velocity = direction * _speed;

            yield return wait;
        }
    }
}
