using UnityEngine;
using UnityEngine.Events;

public class GunManager : MonoBehaviour
{

    public GameObject bullet;
    public int TotalBullets = 10;
    public UnityEvent OnShoot;
    private Transform firePoint;

    [SerializeField] private AudioClip shootSound;
    //[SerializeField] private AudioClip backgroundMusic;
    private AudioSource audioSource;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        firePoint = GameObject.Find("FirePoint").transform;

        audioSource = GetComponent<AudioSource>();

        // audioSource.clip = backgroundMusic;
        //     audioSource.Play();

        //     SoundManager soundManager = FindObjectOfType<SoundManager>();
        // if (soundManager != null) soundManager.PlaySound(transform.position, "Music");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && TotalBullets > 0)
        {
            Shoot();

            audioSource.clip = shootSound;
            audioSource.Play();
        }
    }
// Method to shoot a bullet
    void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        TotalBullets--;
        OnShoot?.Invoke();

        SoundManager soundManager = FindObjectOfType<SoundManager>();
        if (soundManager != null) soundManager.PlaySound(transform.position, "Shoot");
    }
}
