using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Material normalMaterial;
    public Material transparentMaterial;
    private Renderer ghostRenderer;
    private Collider ghostCollider;
    public bool isStunned = false;

    private Transform target;
    private Rigidbody rb;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ghostRenderer = GetComponent<Renderer>();
        ghostCollider = GetComponent<Collider>();   
        speed = 1;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
     if (target != null)
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
    }
    
 // Update is called once per frame
    void Update()
{
    transform.position = Vector3.MoveTowards(
        transform.position,
        target.position,
        speed * Time.deltaTime
    );
}
// Handle collisions with traps and bullets
    void OnTriggerEnter(Collider other)
    {
       

        if (other.CompareTag("Trap"))
        {
            //Destroy(gameObject);
        }

        if (other.CompareTag("Bullet"))
        {
            
            StartCoroutine(ChangeAfterDelay());
        }
    }
// Coroutine to handle the stun effect
    private IEnumerator ChangeAfterDelay()
    {
        isStunned = true;
        speed = 0;
        if (ghostRenderer != null)
        {
            ghostRenderer.material = transparentMaterial;
        }
        if (ghostCollider != null)        {
            ghostCollider.enabled = false;
        }
        yield return new WaitForSeconds(1f);
        speed = 1;
        if (ghostRenderer != null)
        {
            ghostRenderer.material = normalMaterial;
        }
        if (ghostCollider != null)        {
            ghostCollider.enabled = true;
        }
        isStunned = false;
    }
    

        
    }

