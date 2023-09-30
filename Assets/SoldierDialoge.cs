using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierDialoge : MonoBehaviour
{
    [SerializeField] private GameObject eInteract;
    private bool isTalking;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            eInteract.SetActive(true);
        }
        else
        {
            eInteract.SetActive(false);
        }
    }
}
