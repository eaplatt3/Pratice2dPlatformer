using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFall : MonoBehaviour
{
    //Variable for Delaying Drop 
    public float fallDelay = 1f;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    //When Player Collides with Platfrom it Falls
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Invoke("Fall", fallDelay);

    }

    void Fall()
    {
        rb2d.isKinematic = false; //Sets that Collisions will effect the Rigidbody
    }

}
