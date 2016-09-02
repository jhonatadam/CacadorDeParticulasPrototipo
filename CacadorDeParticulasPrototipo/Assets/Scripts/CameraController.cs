using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;
	public GroundCheckController groundCheck;
	private Rigidbody2D playerRb2d;
    public float leftLimit;
    public float rightLimit;

    private float yOffset;
	private float factor;

	void Start ()
    {
		playerRb2d = player.gameObject.GetComponent<Rigidbody2D> ();
        yOffset = Mathf.Abs(transform.position.y - player.transform.position.y);
	}
	
	void Update () {
    	
		if (playerRb2d.velocity.y > 0)
		{
			if (factor > 0.5f)
			{
				factor -= 0.02f;
			}
		}
		else
		{
			if (factor < 1.0f) {
				factor += 0.02f;
			}
		}

        if (player.transform.position.x > leftLimit && player.transform.position.x < rightLimit)
        {
			transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + (yOffset * factor), transform.position.z);
        }
        else
        {
			transform.position = new Vector3(transform.position.x, player.transform.position.y + (yOffset * factor), transform.position.z);
        }
	}
}
