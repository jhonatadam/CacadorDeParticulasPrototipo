using UnityEngine;
using System.Collections;

public class FieldEffectController : MonoBehaviour {

    // quanto maior, menor a variação
	public float scaleVariation = 1.0f;

    public float updatePerSecond = 60.0f;

    private float enlapsedTime = 0.0f;

    private Vector3 initialScale;

    void Start () {
		initialScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        enlapsedTime += Time.deltaTime;

        if (enlapsedTime > 1 / updatePerSecond)
        {
            enlapsedTime -= (1 / updatePerSecond);

            transform.localScale = new Vector3(
                initialScale.x + Random.value / scaleVariation,
                initialScale.y + Random.value / scaleVariation,
                initialScale.z
            );
        }

	}
}
