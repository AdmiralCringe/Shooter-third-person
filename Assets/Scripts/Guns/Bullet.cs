using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _forceStrenth;
    [SerializeField] private float _lifeTime;
    [SerializeField] private Image bulletHole;

    private Rigidbody _rigidbody;
    
    public float damage;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(transform.forward * _forceStrenth, ForceMode.Impulse);
        Destroy(gameObject, _lifeTime);
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        // if (collision.gameObject.CompareTag("Enemy"))
        // {
        //     collision.gameObject.GetComponent<Enemy>().GetDamage(damage);
        //     Destroy(gameObject);
        // }
        Destroy(gameObject);
    }
}
