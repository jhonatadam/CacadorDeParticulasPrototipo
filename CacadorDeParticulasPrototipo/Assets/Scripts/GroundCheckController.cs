﻿using UnityEngine;
using System.Collections;
using System;

public class GroundCheckController : MonoBehaviour {

    private bool grounded = false;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
			print ("aqui");
            grounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
		if (other.gameObject.tag == "Ground")
		{
			grounded = false;
		}
    }

    public bool isGrounded ()
    {
        return grounded;

    }

}
