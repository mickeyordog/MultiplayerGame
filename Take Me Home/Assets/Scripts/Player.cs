using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 5f;
    Camera cam;
    private Vector2 movement;
    Vector2 mousePos;
    public GameObject missile;
    public Transform firePoint;
    private float nextFireTime;
    private float fireRate = 5f;
    public float health = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Time.time > nextFireTime && Input.GetButton("Jump"))
            FireMissile();
    }

    private void FireMissile()
    {
        GameObject projectile = Instantiate(missile, firePoint.position, Quaternion.identity);
        Rigidbody2D new_rb = projectile.GetComponent<Rigidbody2D>();
        new_rb.rotation = rb.rotation;
        new_rb.velocity = transform.up * -10f;
        Destroy(projectile, 2f);
        nextFireTime = Time.time + 1 / fireRate;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;
        rb.rotation = angle;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Projectile projectile = collision.transform.GetComponent<Projectile>();
        if (projectile)
        {
            health--;
            Destroy(projectile.gameObject);
        }
    }

}
