using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        float scale = Random.Range(.1f, 2f);

        transform.localScale = new Vector2(scale, scale);

        float x = Random.Range(-5f, 5f);
        float y = Random.Range(-5f, 5f);

        rb.velocity = new Vector2(x, y);
    }
}
