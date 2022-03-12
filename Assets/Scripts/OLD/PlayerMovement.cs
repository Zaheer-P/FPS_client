using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    public Transform camera;
    public Rigidbody rb;

    public float camRotationSpeed = 5f;
    public float cameraMinimumY = -60f;
    public float cameraMaximumY = 75f;
    public float rotationSmoothSpeed = 10f;

    public float walkSpeed = 10f;
    public float runSpeed = 15f;
    public float maxSpeed = 20f;
    public float jumpPower = 30f;

    public bool grounded;
    private PlayerFootsteps playerFootsteps;
    private float WalkMinVolume = 0.2f, WalkMaxVolume = 0.6f, WalkStepDistance = 0.4f;


    float bodyRotationX;
    float camRotationY;
    Vector3 directionIntentX;
    Vector3 directionIntentY;
    float speed;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        playerFootsteps = GetComponentInChildren<PlayerFootsteps>();
    }

    void Start()
    {
        playerFootsteps.volume_Min = WalkMinVolume;
        playerFootsteps.volume_Max = WalkMaxVolume;
        playerFootsteps.stepDistance = WalkStepDistance;
        
    }

    //functions
    void Update()
    {
        LookRotation();
        Movement();
        GroundCheck();
        if (grounded && Input.GetButtonDown("Jump"))
        {
            grounded = false;
            Jump();
        }
        

    }
    void LookRotation()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            //get camera and body rotational values
            bodyRotationX += Input.GetAxis("Mouse X") * camRotationSpeed;
            camRotationY += Input.GetAxis("Mouse Y") * camRotationSpeed;


            //stop camera rotating 360
            camRotationY = Mathf.Clamp(camRotationY, cameraMinimumY, cameraMaximumY);

            //create rotation target and handle rotations of body and cam
            Quaternion camTargetRotation = Quaternion.Euler(-camRotationY, 0, 0);
            Quaternion bodyTargetRotation = Quaternion.Euler(0, bodyRotationX, 0);

            //handle rotations
            transform.rotation = Quaternion.Lerp(transform.rotation, bodyTargetRotation, Time.deltaTime * rotationSmoothSpeed);
            camera.localRotation = Quaternion.Lerp(camera.localRotation, camTargetRotation, Time.deltaTime * rotationSmoothSpeed);


        }

    void Movement()
        {
            //direction matches camera direction
            directionIntentX = camera.right;
            directionIntentX.y = 0;
            directionIntentX.Normalize();

            directionIntentY = camera.forward;
            directionIntentY.y = 0;
            directionIntentY.Normalize();

            //change charicters velocity in this direction
            rb.velocity = directionIntentY * Input.GetAxis("Vertical") * speed + directionIntentX * Input.GetAxis("Horizontal") * speed + Vector3.up * rb.velocity.y;
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

            //control speed based on movement state
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = runSpeed;
            }
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                speed = walkSpeed;
            }
            if (Input.GetButton("Vertical"))
             {
                anim.SetBool("isWalking", true);
            }
            else
            {
                anim.SetBool("isWalking", false);
            }
    }

    void GroundCheck()
        {
            //casts a ray of a length of 0.85 in a downward direction and if the ray hits a surface grounded is set to true
            RaycastHit groundHit;
            grounded = Physics.Raycast(transform.position, -transform.up, out groundHit, 0.85f);
        }

    void Jump()
        {
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

    }

    
}
