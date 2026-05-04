using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float aliveTime = 3f;
    public float damageAmount = 25f;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);
        Destroy(gameObject, aliveTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);

        if (other.tag == "Player" || other.tag == "Gun") return;
        if (other.tag == "Enemy") Destroy(other.gameObject);
        if (other.tag == "Target") Destroy(other.gameObject);
    }
}