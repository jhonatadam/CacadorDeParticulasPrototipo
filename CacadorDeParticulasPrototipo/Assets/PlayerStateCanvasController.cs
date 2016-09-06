using UnityEngine;
using System.Collections;

public class PlayerStateCanvasController : MonoBehaviour {

	public GameObject lifeBar;
	public GameObject energyBar;

	public void SetLifeBar (float percent) {
		lifeBar.transform.localScale = new Vector3 (2.0f * percent, 0.1f, 1.0f);
	}

	public void SetEnergyBar (float percent) {
		energyBar.transform.localScale = new Vector3 (2.0f * percent, 0.1f,  1.0f);
	}
}
