using UnityEngine;
using System.Collections;
using System;

public class GroundCheckController : MonoBehaviour {

    private bool grounded = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        grounded = false;
    }

    public bool isGrounded ()
    {
        return grounded;

    }

}
