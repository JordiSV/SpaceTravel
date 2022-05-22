using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    [HideInInspector]
    public Rigidbody2D rb;
    private GravityController gravity;
    public Vector2 propulsion;
    public AudioSource boom;
    public AudioSource hit;
    int lives = 3;

    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        gravity = GetComponent<GravityController>();
    }

    
    void Update()
    {   
        rb.velocity = propulsion + gravity.attractionForce;
    }

    internal void slowDown()
    {
        if (propulsion.magnitude > 0f)
            propulsion -= propulsion.normalized * Time.deltaTime;

        if (propulsion.magnitude < 0f)
            propulsion = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid") {
            if (--lives == 0)
            {
                AudioManager.instance.playSound(0);

                Destroy(gameObject);
            }
            else
                AudioManager.instance.playSound(1);

        }
    }
}
