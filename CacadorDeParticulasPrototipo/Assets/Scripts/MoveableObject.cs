using UnityEngine;
using System.Collections;

public class MoveableObject : MonoBehaviour {

    public GameObject player;
    public Vector2 velocity;

    private Rigidbody2D rb2d;

	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
	    if (player.transform.position.x > 22)
        {
            rb2d.velocity = velocity;
        }        
	}
}
