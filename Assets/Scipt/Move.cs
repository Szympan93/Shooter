using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour 
{
	public Vector2 speed;
	public Vector2 acceleration;
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		speed += acceleration * Time.deltaTime;
		transform.Translate (speed * Time.deltaTime);
	}
}
