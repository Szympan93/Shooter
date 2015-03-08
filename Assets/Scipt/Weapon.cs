using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour 
{
	public GameObject missile;
	public float delay;

	private float shootTime;

	void Start ()
	{
		shootTime = Time.time + delay;
	}

	void Update ()
	{
		if (Time.time >= shootTime && Input.GetMouseButton (0))
		{
			Instantiate(missile, transform.position, transform.rotation);
			shootTime = Time.time + delay;
		}
	}
}
