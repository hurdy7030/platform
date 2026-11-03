using UnityEngine;
using UnityEngine.InputSystem;

public class playerbehav : MonoBehaviour
{
    private Vector2 spawnpoint;
    
    private InputAction moveInput;
    public float force;
    public float speed;
    public Rigidbody2D mybody;
   
    private Vector2 inputForce;
    private float inputTime = 0f;
    
    private InputAction JumpInput;
    public float jumpPower;
    private bool Jump;
    private bool onGround;


    public Transform groundcheck;
    public float checksize;
    public LayerMask groundLayer;
   
    public float curvature = 1f;
    public float decurvature = - 1f;
    
    
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnpoint = mybody.position;
       moveInput = InputSystem.actions.FindAction("move"); 
       JumpInput =  InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        inputForce = moveInput.ReadValue<Vector2>();
        if (JumpInput.WasPressedThisFrame())
            Jump = true;

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Spike")
        {
            mybody.position = spawnpoint;
        }
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(inputForce.x) > 0.01f)
        {
            inputTime += Time.fixedDeltaTime;
        }
        else
        {
            inputTime = 0f;
        }
        
       float t = Mathf.Clamp01(inputTime / 1f);
       float acceleration = (Mathf.Exp(t * curvature) - 1f) / (Mathf.Exp(curvature) - 1f);
       float deacceleration = (Mathf.Exp(t * decurvature) - 1f) / (Mathf.Exp(decurvature) - 1f);

       mybody.linearVelocityX = inputForce.x * speed * acceleration;
       
    
       onGround = Physics2D.OverlapCircle(groundcheck.position, checksize, groundLayer);
       
       if(Jump && onGround)
       {
           mybody.linearVelocityY = jumpPower;
       }
       Jump = false;
       
       if(onGround == false)
       {
           mybody.linearVelocityX = inputForce.x * speed * deacceleration;
       }
       
    }
}
