using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Player Movement Speed
    public float moveSpeed = 5f; 
    //Sets Player Jump force Variable
    public float jumpStrength = 5f;
    //Sets Player Rigid Body variable
    private Rigidbody rb;
    //Bool to Check if on the ground
    public bool OnGround = true;
    //Bool to turn on player jump
    public bool doJump = false;
    //Creates variable to choose smoothing
    [SerializeField] private float smoothTime;
    //Spawnpoint for thrown Gadget
    public Transform throwPoint;
    //Force for thrown gadget
    [SerializeField] private float throwForce = 10f;
    //Gadget to Throw
    public GameObject gadgetToThrow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Finds Player Rigid Body
        rb = GetComponent<Rigidbody>();
    }
// Update is called once per frame
    void Update()
    {   
        //Tells player if space is pressed then it is allowed to jump (For some reason this was inconsistent in Void FixedUpdate)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            doJump = true;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    
    void FixedUpdate()
    {
        //Sets player horizontal and vertical variables
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        //Sets player Velocity and tell player to move in chosen axis direction
        Vector3 move = new Vector3(h * moveSpeed, rb.linearVelocity.y, v * moveSpeed);

        rb.linearVelocity = move;

        //Checks if Space button was pressed and if player is on the ground plane, then applys upward force if so
        if (doJump && OnGround)
        {
            rb.AddForce(Vector3.up *jumpStrength, ForceMode.Impulse);
            doJump = false;
        }
        // Sets Player Rotation to pressed axis key
        Vector3 spin = new Vector3(h, 0, v);

        if (spin != Vector3.zero)
       {
            transform.rotation = Quaternion.LookRotation(spin * smoothTime);
        }        
        
        // If Left Shift is pressed, player sprints at double speed
        if (Input.GetKey(KeyCode.LeftShift) && OnGround)
        {
            rb.linearVelocity *= 2f;
        }
        // If F is pressed, player throws the Trap
        if (Input.GetKeyDown(KeyCode.F) && gadgetToThrow != null)   {
            ThrowGadget();
    }

        

        //Code to spawn and throw the trap, then doesnt allow another to be thrown
    void ThrowGadget()
        {
            GameObject thrownGadget = Instantiate(gadgetToThrow, throwPoint.position, throwPoint.rotation);
            Rigidbody rb = thrownGadget.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddForce(throwPoint.forward * throwForce, ForceMode.VelocityChange);
            }

            gadgetToThrow = null;
        }

    }

    void OnCollisionEnter(Collision collision)
    {   
        
        //If player is touching the ground plane, then enable jump
        if (collision.gameObject.CompareTag("Ground"))
        {
            OnGround = true;
        }

         
        //If enemy touches player, player dies 
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            Destroy(gameObject);
            //SceneManager.LoadScene(2);

            
        }
    
        
    
    }

    void OnCollisionExit(Collision collision)
    {
        //If player is not touching the ground plane, then disable jump
        if (collision.gameObject.CompareTag("Ground"))
        {
            OnGround = false;
        }
    }

    
}
