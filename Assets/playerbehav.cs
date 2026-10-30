using UnityEngine;
using UnityEngine.InputSystem;

public class playerbehav : MonoBehaviour
{
    private InputAction moveInput;
    public float force;
    public float speed;
    public float jumpPower;
    public Rigidbody2D mybody;
    private Vector2 inputForce;
    private float inputTime = 0f;

    public Transform groundcheck;
    public float checksize;
    public LayerMask groundLayer;
    public float curvature = 1f;
    
    private bool onGround;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       moveInput = InputSystem.actions.FindAction("move"); 
       
    }

    // Update is called once per frame
    void Update()
    {
        inputForce = moveInput.ReadValue<Vector2>();
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

       mybody.linearVelocityX = inputForce.x * speed * acceleration;
       
       
       onGround = Physics2D.OverlapCircle(groundcheck.position, checksize, groundLayer);
       
       if(inputForce.y > 0 && onGround)
       {
           mybody.linearVelocityY = inputForce.y*jumpPower;
       }
       
       /*if(onGround == false)
       {
           mybody.linearVelocityX = inputForce.x * speed * 0.4f;
           
       }*/
       
    }
}
