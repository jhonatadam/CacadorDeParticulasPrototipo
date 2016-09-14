using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private float life = 100.0f;
	private float energy = 0.0f;

	public PlayerStateCanvasController playerStateCanvas;

    public Rigidbody2D rb2d;
    public float speed;
    public float jumpForce;

    public GameObject forceField;
	public AudioSource musicSource;

    private Animator anim;

    private bool isFacingRight;
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
			if (energy > 0.0f) {
				forceField.SetActive(!forceField.activeSelf);
				if (musicSource.isPlaying) {
					musicSource.Pause ();
				} else {
					musicSource.Play ();
				}
			}
        }	

		if (energy <= 0.0f) {
			forceField.SetActive (false);
			musicSource.Pause ();
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

        if (groundCheck.isGrounded()) {
			if (rb2d.velocity.x != 0.0f) {
                anim.SetTrigger("walk");
            }
            else {
                anim.SetTrigger("stop");
            }
        } else {
				anim.SetTrigger ("jump");
        }

		if (forceField.activeSelf) {
			energy -= 0.1f;
			playerStateCanvas.SetEnergyBar (energy / 100.0f);
		}
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "GoodParticle") {
			Destroy (other.gameObject);
			energy += 10.0f;
			if (energy > 100.0f) {
				energy = 100.0f;
			}
			playerStateCanvas.SetEnergyBar (energy / 100.0f);
		}

		if (other.gameObject.tag == "BadParticle") {
			Destroy (other.gameObject);
			float damage = 10.0f;
			if (life > damage) {
				life -= damage;
				playerStateCanvas.SetLifeBar (life / 100.0f);
			} else {
				// morreu
			}
		}
	}
}
