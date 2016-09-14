using UnityEngine;
using System.Collections;

public class ElevatorController : MonoBehaviour {

	private bool hasPlayer = false;
	private float speed = 0.04f;
	private float destiny = 0.0f;

	void FixedUpdate () {
		if (hasPlayer) {
			this.transform.position = new Vector2(this.transform.position.x, 
				this.transform.position.y + speed);
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			hasPlayer = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			hasPlayer = false;
		}
	}
}
