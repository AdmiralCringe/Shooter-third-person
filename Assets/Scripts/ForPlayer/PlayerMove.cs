using System;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float runSpeed;
    [SerializeField] private float aimSpeed;
    [SerializeField] private float gravityPower;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float distanceToGround;
    [SerializeField] private float jumpPower;
    [SerializeField] private Animator animator;
    [SerializeField] private Camera cam;
    [SerializeField] public Transform point;
    [SerializeField] public Transform checkGround;
    [SerializeField] public LayerMask groundMask;

    private MultiAimConstraint spineRig;
    
    private Vector3 directionX;
    private Vector3 directionZ;
    private Vector3 directionY;
    private Vector3 moveDirection;
    
    private float verticalVelocity;
    private float mouseY;
    private float targetWeight;

    private bool isAiming;
    private bool isGrounded;
    private bool isJumping;

    private CharacterController _characterController;
    private CameraController _cameraController;


    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _cameraController = GameObject.Find("MainCamera").GetComponent<CameraController>();
        spineRig = GameObject.Find("RiggingSpine").GetComponent<MultiAimConstraint>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Gravity();
        Move();
        Jump();
    }

    public void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        animator.SetFloat("speedVertical", vertical);
        animator.SetFloat("speedHorizontal", horizontal);
        directionX = new Vector3(transform.position.x - cam.transform.position.x, 0, transform.position.z - cam.transform.position.z);
        directionZ = new Vector3(transform.position.z - cam.transform.position.z, 0, transform.position.z - point.transform.position.z);
        
        moveDirection = Vector3.ClampMagnitude((directionZ * horizontal) + (directionX * vertical), 1);
        Vector3 dir = transform.position - cam.transform.position;
        
        if ((horizontal != 0 || vertical != 0) && !isAiming)
        {
            Vector3 eulerAngles = Quaternion.LookRotation(moveDirection).eulerAngles;
            eulerAngles.x = 0;
            eulerAngles.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(eulerAngles), Time.deltaTime * rotationSpeed);
            
            _characterController.Move(moveDirection * (runSpeed * Time.deltaTime));
            
            spineRig.weight = 0f;
            
            animator.SetBool("isStoping", false);
        }else {
            animator.SetBool("isStoping", true); 
        }
        
        
        if (Input.GetKey(KeyCode.Mouse1))
        {
            isAiming = true;
            Vector3 eulerAngles = Quaternion.LookRotation(dir).eulerAngles;
            eulerAngles.x = 0;
            eulerAngles.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(eulerAngles), Time.deltaTime * rotationSpeed);
            
            _cameraController.PlayerAiming();
            _characterController.Move(moveDirection * (aimSpeed * Time.deltaTime));
            spineRig.weight = 1f;
            animator.SetBool("isAiming", true);
        }else
        {
            isAiming = false;
            animator.SetBool("isAiming", false);
        }
        moveDirection.Normalize();
    }

    private void Gravity()
    {
        directionY.y -= gravityPower * Time.deltaTime;
        _characterController.Move(directionY * Time.deltaTime);
        
    }

    private void Jump()
    {
        isGrounded = Physics.CheckSphere(checkGround.position, distanceToGround, groundMask);

        if (isGrounded)
        {
            animator.SetBool("isFalling", false);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                directionY.y = jumpPower;
                animator.SetTrigger("isJumping");
            }
        }
        else
        {
            animator.SetBool("isFalling", true);
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(checkGround.position, distanceToGround);
    }
}
