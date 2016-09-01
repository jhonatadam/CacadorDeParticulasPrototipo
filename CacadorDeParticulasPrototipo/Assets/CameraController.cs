using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public float leftLimit;
    public float rightLimit;

    private float yOffset;

	// Use this for initialization
	void Start ()
    {
        yOffset = Mathf.Abs(transform.position.y - player.transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
       
        if (player.transform.position.x > leftLimit && player.transform.position.x < rightLimit)
        {
            transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + yOffset, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y + yOffset, transform.position.z);
        }
	}
}
