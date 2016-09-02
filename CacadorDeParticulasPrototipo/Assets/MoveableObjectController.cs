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

        public Action (Vector2 point, GameObject obj, Vector2 position, Vector2 velocity)
        {
            this.point = point;
            this.obj = obj;
            this.position = position;
            this.velocity = velocity;
        }
    }

    public GameObject player;

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
            goodParticle,
            new Vector2 (34, 8),
            new Vector2(0, -2)
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
                Instantiate(triggerPoints[i].obj, triggerPoints[i].position, transform.rotation);
                triggerPoints.RemoveAt(i);
            }
            else
            {
                i++;
            }
        }
	}
}