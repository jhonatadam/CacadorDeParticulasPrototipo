using UnityEngine;
using System.Collections;

public class RedFieldController : MonoBehaviour {

	public float variation = 1;
	private Vector3 initialScale;

	// Use this for initialization
	void Start () {
		initialScale = transform.localScale;
	}

	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3 (
			initialScale.x + Random.value / variation, 
			initialScale.y + Random.value / variation, 
			initialScale.z
		);
	}
}
