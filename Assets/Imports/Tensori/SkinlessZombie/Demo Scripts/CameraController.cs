using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    
    private Vector3 playerDiretion;
    private Vector3 cameraDiretion;
    
    private float xRotation;
    private float yRotation;
    
    private RaycastHit hit;
    public Transform mainCamera;
    public GameObject pointAiming;
    public LayerMask layerMasks;

    private void Start()
    {
        pointAiming = GameObject.Find("Aim");
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        yRotation -= mouseY;
        xRotation -= mouseX;
        yRotation = Mathf.Clamp(yRotation, -60f, 60f);
        
        target.localRotation = Quaternion.Euler(yRotation, -xRotation, 0);
    }

    public void PlayerAiming()
    {
        if (Physics.Raycast(mainCamera.position, mainCamera.forward * 99999, out hit, layerMasks))
        {
            pointAiming.transform.position = hit.point;
        }
    }
}
