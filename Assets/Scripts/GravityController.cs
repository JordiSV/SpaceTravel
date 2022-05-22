using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public GameObject blackHole;
    Rigidbody2D rb;

    public Vector2 attractionForce = Vector2.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (blackHole != null)
        {
            Vector2 toBlackHole = blackHole.transform.position - transform.position;
            attractionForce = toBlackHole / Mathf.Pow( .5f * toBlackHole.magnitude, 2) * Time.deltaTime;

            rb.velocity += attractionForce;
        }
    }
}
