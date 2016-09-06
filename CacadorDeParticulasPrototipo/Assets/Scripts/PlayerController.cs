using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D rb2d;
    public float speed;
    public float jumpForce;

    public GameObject forceField;
	public AudioSource musicSource;

    private Animator anim;

    private bool isFacingRight = true;
    public GroundCheckController groundCheck;

    void Start ()
    {
        anim = GetComponent<Animator>();
    }

	void Update ()
    {
        if (groundCheck.isGrounded())
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb2d.AddForce(new Vector2(0, jumpForce));
            }
        }

        if (Input.GetKeyDown (KeyCode.F))
        {
            forceField.SetActive(!forceField.activeSelf);
			if (musicSource.isPlaying) {
				musicSource.Pause ();
			} else {
				musicSource.Play ();
			}

        }	

        if (Input.GetKey (KeyCode.LeftControl))
        {
            if (Time.timeScale > 0.2f)
            {
                Time.timeScale -= 0.1f;
            }
        }
        else
        {
            if (Time.timeScale < 1.0f)
            Time.timeScale += 0.1f;
        }

	}

    void FixedUpdate ()
    {

        float horizontalMovement = Input.GetAxis("Horizontal");

        rb2d.velocity = new Vector2(horizontalMovement * speed, rb2d.velocity.y);

        if (horizontalMovement < 0)
        {
            isFacingRight = false;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (horizontalMovement > 0)
        {
            isFacingRight = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (groundCheck.isGrounded())
        {
            if (horizontalMovement != 0)
            {
                anim.SetTrigger("walk");
            }
            else
            {
                anim.SetTrigger("stop");
            }
        }
        else
        {
            anim.SetTrigger("jump");
        }

    }
}
