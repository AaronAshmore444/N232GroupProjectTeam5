using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public float speed = 20f;
    public float aliveTime = 3f;
    public float damageAmount = 25;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);
        Destroy(gameObject, aliveTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);

        if (other.tag == "Player" || other.tag == "Gun") return;
        
        if (other.tag == "Target") Destroy(other.gameObject);
        

        Destroy(gameObject);
    }
}