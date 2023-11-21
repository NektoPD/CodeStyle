using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private GameObject _bulletTemplate;
    [SerializeField] private float _shootingCooldown;
    [SerializeField] private Transform _target;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool isWorking = enabled;
        Rigidbody newBulletRigidbody;
        WaitForSeconds cooldown = new WaitForSeconds(_shootingCooldown);

        while (isWorking)
        {
            Vector3 targetDistance = (_target.position - transform.position).normalized;
            GameObject NewBullet = Instantiate(_bulletTemplate, transform.position + targetDistance, Quaternion.identity);
            newBulletRigidbody = NewBullet.GetComponent<Rigidbody>();
            
            newBulletRigidbody.transform.up = targetDistance;
            newBulletRigidbody.velocity = targetDistance * _bulletSpeed;

            yield return cooldown;
        }
    }
}