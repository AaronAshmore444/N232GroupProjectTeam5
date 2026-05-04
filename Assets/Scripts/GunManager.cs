using UnityEngine;

public class GunManager : MonoBehaviour
{

    public GameObject bullet;
    private Transform firePoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        firePoint = GameObject.Find("FirePoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Shoot();
        }
    }
// Method to shoot a bullet
    void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
