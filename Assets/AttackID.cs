using UnityEngine;

public class AttackID : MonoBehaviour
{
    public Transform hand;
    private Transform target;
    
    public void Update()
    {
        target = GameObject.Find("Pick").transform;
        hand.position = target.position;
        hand.rotation = target.rotation;
    }
}
