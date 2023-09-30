using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject player;
    private RaycastHit hit;
    private Vector3 directionToPlayer;

    private void Start()
    {
        player = GameObject.Find("TagPlayer");
    }

    void Update()
    {
        
        directionToPlayer = new Vector3(player.transform.position.x - transform.position.x, 
            player.transform.position.y - transform.position.y, 
            player.transform.position.z - transform.position.z);
        if (Physics.Raycast(transform.position, player.transform.position, out hit, 550))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                Debug.DrawRay(transform.position, directionToPlayer * 550, Color.red);
            }
            else
            {
                Debug.DrawRay(transform.position, directionToPlayer * 550, Color.green);
            }
        }
    }
}