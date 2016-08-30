using UnityEngine;
using System.Collections;

public class ForceFieldController : MonoBehaviour {

    public GameObject fieldEffectRed;
    public GameObject fieldEffectGreen;
    public GameObject fieldEffectBlue;

	void Update () {
	    if (Random.value < 0.2)
        {
            fieldEffectRed.active = !fieldEffectRed.active;
        }

        if (Random.value < 0.2)
        {
            fieldEffectGreen.active = !fieldEffectGreen.active;
        }

        if (Random.value < 0.2)
        {
            fieldEffectBlue.active = !fieldEffectBlue.active;
        }
    }
}
