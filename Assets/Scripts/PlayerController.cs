using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Player Movement Speed
    public float moveSpeed = 5f;
    public float sprintSpeed = 10f;
    //Sets Player Jump force Variable

    public float verticalVelocity = 0f;
    public float jumpStrength = 5f;
    
    public CharacterController controller;

    public Transform cameraTransform;

    //Bool to Check if on the ground
    public bool OnGround = true;
    //Bool to turn on player jump
    public bool doJump = false;
    //Spawnpoint for thrown Gadget
    public Transform throwPoint;
    //Force for thrown gadget
    [SerializeField] private float throwForce = 10f;
    //Gadget to Throw
    public GameObject gadgetToThrow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }
    // Update is called once per frame
    void Update()
    {

        OnGround = controller.isGrounded;

        if (OnGround && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        movement = cameraTransform.TransformDirection(movement);
        movement.y = 0;
        movement = movement.normalized;
        
        float currentSpeed = moveSpeed;

        if (Input.GetKey(KeyCode.LeftShift) && OnGround)
        {
            currentSpeed = sprintSpeed;
        }

        

        

        
        //Tells player if space is pressed then it is allowed to jump (For some reason this was inconsistent in Void FixedUpdate)
        if (Input.GetKeyDown(KeyCode.Space) && OnGround)
        {
            verticalVelocity = jumpStrength;
        }

        if (!OnGround)
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }
        Vector3 allMovement = movement * currentSpeed;
        allMovement.y = verticalVelocity;
        controller.Move(allMovement * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }


    void FixedUpdate()
    { 
      
        // If F is pressed, player throws the Trap
        if (Input.GetKeyDown(KeyCode.F) && gadgetToThrow != null)
        {
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



        //If enemy touches player, player dies 
        if (collision.gameObject.CompareTag("Enemy"))
        {

            Destroy(gameObject);
            //SceneManager.LoadScene(2);


        }



    }

    
}
