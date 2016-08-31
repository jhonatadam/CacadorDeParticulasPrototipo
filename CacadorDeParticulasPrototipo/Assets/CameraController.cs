using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
       
        if (player.transform.position.x > 0 && player.transform.position.x < 16)
        {
            transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        }
	}
}
