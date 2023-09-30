using System;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Rigidbody shard;
    void Start()
    {
        shard = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        shard.AddRelativeForce(Vector3.forward * 10);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        if (collision.collider.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HealthPlayer>().GetDamage(10);
        }
    }
}
