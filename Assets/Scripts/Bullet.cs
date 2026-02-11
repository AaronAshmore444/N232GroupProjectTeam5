using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public float aliveTime = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);

        Destroy(gameObject, aliveTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") return;
        if (other.tag == "Enemy") Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
