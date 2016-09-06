using UnityEngine;
using System;
using System.Collections.Generic;

public class MoveableObjectController : MonoBehaviour {

    private struct Action
    {
        public Vector2 point;
        public GameObject obj;
        public Vector2 position;
        public Vector2 velocity;
		public float timeLife;

        public Action (Vector2 point, GameObject obj, Vector2 position, 
			Vector2 velocity, float timeLife)
        {
            this.point = point;
            this.obj = obj;
            this.position = position;
            this.velocity = velocity;
			this.timeLife = timeLife;
        }
    }

    public GameObject player;

	public GameObject rock;
    public GameObject goodParticle;
    public GameObject badParticle;

    public Vector2 tolerance;
    private List<Action> triggerPoints;


    void Start()
    {
        triggerPoints = new List<Action>();

        // pedra caindo
        triggerPoints.Add(new Action(
            new Vector2(22, 2),
			rock,
            new Vector2 (34, 8),
            new Vector2(0.0f, 0.0f),
			0.0f
        ));

		// Particula boa 1
		triggerPoints.Add(new Action(
			new Vector2(6.5f, 3.0f),
			goodParticle,
			new Vector2 (14.0f, 9.0f),
			new Vector2(1.0f, -4.0f),
			10.0f
		));

		// Particula boa 2
		triggerPoints.Add(new Action(
			new Vector2(19.0f, 3.0f),
			goodParticle,
			new Vector2 (24.0f, 9.0f),
			new Vector2(0.0f, -5.5f),
			10.0f
		));

		// Particula boa 3
		triggerPoints.Add(new Action(
			new Vector2(24.0f, 3.0f),
			goodParticle,
			new Vector2 (30.0f, 9.0f),
			new Vector2(0.5f, -3.5f),
			10.0f
		));

		// Particula boa 4
		triggerPoints.Add(new Action(
			new Vector2(26.0f, 3.0f), //posição de gatilho
			goodParticle, // objeto
			new Vector2 (35.0f, 10.0f), // posição inicial
			new Vector2(-2.5f, -5.5f), // velocidade
			10.0f // tempo de vida
		));

		// Particula boa 5
		triggerPoints.Add(new Action(
			new Vector2(33.0f, 5.0f),   //posição de gatilho
			goodParticle,               // objeto
			new Vector2 (33.0f, 16.0f), // posição inicial
			new Vector2(-2.0f, -4.5f),  // velocidade
			10.0f // tempo de vida
		));

		// Particula boa 6
		triggerPoints.Add(new Action(
			new Vector2(28.0f, 8.0f),   //posição de gatilho
			goodParticle,               // objeto
			new Vector2 (24.0f, 16.0f), // posição inicial
			new Vector2(-1.0f, -5.0f),  // velocidade
			10.0f // tempo de vida
		));

		// Particula boa 7
		triggerPoints.Add(new Action(
			new Vector2(24.0f, 8.0f),   //posição de gatilho
			goodParticle,               // objeto
			new Vector2 (20.0f, 16.0f), // posição inicial
			new Vector2(-1.0f, -5.0f),  // velocidade
			10.0f // tempo de vida
		));

		// Particula boa 8
		triggerPoints.Add(new Action(
			new Vector2(20.0f, 8.0f),   //posição de gatilho
			goodParticle,               // objeto
			new Vector2 (18.0f, 16.0f), // posição inicial
			new Vector2(-2.2f, -7.0f),  // velocidade
			10.0f // tempo de vida
		));

		// Particula ruim 1
		triggerPoints.Add(new Action(
			new Vector2(2.0f, 10.0f),   //posição de gatilho
			badParticle,               // objeto
			new Vector2 (8.0f, 19.0f), // posição inicial
			new Vector2(-6.0f, -8.0f),  // velocidade
			10.0f // tempo de vida
		));

		// Particula ruim 2
		triggerPoints.Add(new Action(
			new Vector2(8.0f, 14.0f),   //posição de gatilho
			badParticle,               // objeto
			new Vector2 (8.0f, 20.0f), // posição inicial
			new Vector2(3.0f, -8.0f),  // velocidade
			10.0f // tempo de vida
		));

		// Particula ruim 3
		triggerPoints.Add(new Action(
			new Vector2(14.0f, 14.0f),   //posição de gatilho
			badParticle,               // objeto
			new Vector2 (14.0f, 20.0f), // posição inicial
			new Vector2(4.0f, -8.0f),  // velocidade
			10.0f // tempo de vida
		));

		// Particula ruim 4
		triggerPoints.Add(new Action(
			new Vector2(20.0f, 14.0f),   //posição de gatilho
			badParticle,               // objeto
			new Vector2 (32.0f, 22.0f), // posição inicial
			new Vector2(-7.0f, -8.0f),  // velocidade
			10.0f // tempo de vida
		));
	}

	void Update ()
    {
        int i = 0;
	    while (i < triggerPoints.Count)
        {
            if (player.transform.position.x < triggerPoints[i].point.x + tolerance.x &&
                player.transform.position.x > triggerPoints[i].point.x - tolerance.x &&
                player.transform.position.y < triggerPoints[i].point.y + tolerance.y &&
                player.transform.position.y > triggerPoints[i].point.y - tolerance.y)
            {
				GameObject go = (GameObject) Instantiate(triggerPoints[i].obj, triggerPoints[i].position, transform.rotation);
				go.gameObject.GetComponent<Rigidbody2D> ().velocity = triggerPoints [i].velocity;
				if (triggerPoints [i].timeLife > 0.0f)
					Destroy (go, triggerPoints [i].timeLife);
				
                triggerPoints.RemoveAt(i);
            }
            else
            {
                i++;
            }
        }
	}
}