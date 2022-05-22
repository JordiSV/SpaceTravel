using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleController : MonoBehaviour
{
    public float gravityConst;
    AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
            GameCanvasController.instance.EndGame();

        Debug.Log("ahora");
        source.Play();
        Destroy(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        collision.GetComponent<GravityController>().blackHole = gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<GravityController>().blackHole = null;
    }


}
