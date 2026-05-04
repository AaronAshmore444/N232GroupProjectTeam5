using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private Transform target;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 1;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log ("Trigger Hit: " + other.gameObject.tag);

        if (other.CompareTag("Trap"))
        {
            //Destroy(gameObject);
        }

        if (other.CompareTag("Bullet"))
        {
            
            StartCoroutine(ChangeAfterDelay());
        }
    }

    private IEnumerator ChangeAfterDelay()
    {
        speed = 0;
        yield return new WaitForSeconds(1f);
        speed = 1;
    }

        
    }

