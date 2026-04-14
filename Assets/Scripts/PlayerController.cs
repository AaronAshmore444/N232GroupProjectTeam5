using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    //Player Movement Speed
    public float moveSpeed = 5f;
    public float sprintSpeed = 10f;
    
    //Variable to control player jump
    public float verticalVelocity = 0f;
    //Sets Player Jump force Variable
    public float jumpStrength = 5f;
    //Get player Controller
    public CharacterController controller;
    //Set camera to transform
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
    //Bool to check if player has a gadget
    public bool hasGadget;

    
    //Sets player current gadget
    public GameObject currentGadget;
    //Sets Text for trap pickup
    public GameObject pickupTrapText;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Set has gadget to True
        hasGadget = true;
        
    }
    // Update is called once per frame
    void Update()
    {
        //If on ground, player is grounded
        OnGround = controller.isGrounded;
        //Controls Player jump height and helps gravity
        if (OnGround && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }
        //Set player horizontal and vertical movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //Moves Player on X and Z
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        movement = cameraTransform.TransformDirection(movement);
        movement.y = 0;
        movement = movement.normalized;
        
        float currentSpeed = moveSpeed;
        // If press left shift and player is on ground, run at sprint speed
        if (Input.GetKey(KeyCode.LeftShift) && OnGround)
        {
            currentSpeed = sprintSpeed;
        }

        

        

        
        //If player presses Space, Jump using jumpStrength
        if (Input.GetKeyDown(KeyCode.Space) && OnGround)
        {
            verticalVelocity = jumpStrength;
        }
        //If palyer is not on ground, apply gravity
        if (!OnGround)
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }
        //Sets all player movement, including on the Y axis
        Vector3 allMovement = movement * currentSpeed;
        allMovement.y = verticalVelocity;
        controller.Move(allMovement * Time.deltaTime);
        //If player presses R, reset scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        // If F is pressed, player throws the Trap
        if (Input.GetKeyDown(KeyCode.F)) {
         
            if (hasGadget)
            {
                ThrowGadget();
            }
            //If player presses F when in a collsion of a thrown trap, pickup the trap
            if (currentGadget != null)
            {
               
                
                 Destroy(currentGadget);
                currentGadget = null;

                GameManager gameManager = FindObjectOfType<GameManager>();
                if (gameManager != null)
             {
                gameManager.AddTrap(1);
             }
             
        
             pickupTrapText.SetActive(false);
        

                hasGadget = true;

                
                
            }

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
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.LoseTrap(1);
            }

            hasGadget = false;
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
    //If player touches traps, display pickup text
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trap"))
        {
            pickupTrapText.SetActive(true);
        }
    }
    //If player leaves trap area, hide pickup text
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Trap"))
        {
            pickupTrapText.SetActive(false);
        }
    }


}
