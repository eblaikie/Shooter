using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    public float fireRate = 0.2f;
    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime) // Left mouse button
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

 if (rb != null)
    {
        rb.linearVelocity = firePoint.forward * bulletSpeed;  // Moves the bullet forward
        Debug.Log("Bullet Fired! Velocity: " + rb.linearVelocity);
    }
    else
    {
        Debug.LogError("Rigidbody not found on bullet!");
    }






        rb.linearVelocity = firePoint.forward * bulletSpeed;
        Destroy(bullet, 3f); // Destroys bullet after 3 seconds
    }
}
