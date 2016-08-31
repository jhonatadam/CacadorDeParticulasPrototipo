using UnityEngine;
using System.Collections;

public class ForceFieldController : MonoBehaviour {

    public GameObject fieldEffectRed;
    public GameObject fieldEffectGreen;
    public GameObject fieldEffectBlue;

    public float updatePerSecond;
    public float changeFactor;

    private float enlapsedTime = 0.0f;


	void Update () {

        enlapsedTime += Time.deltaTime;

        if (enlapsedTime > 1 / updatePerSecond)
        {
            enlapsedTime -= (1 / updatePerSecond);

            if (Random.value < changeFactor)
            {
                fieldEffectRed.SetActive(!fieldEffectRed.activeSelf);
            }

            if (Random.value < changeFactor)
            {
                fieldEffectGreen.SetActive(!fieldEffectGreen.activeSelf);
            }

            if (Random.value < changeFactor)
            {
                fieldEffectBlue.SetActive(!fieldEffectBlue.activeSelf);
            }
        }
    }
}
