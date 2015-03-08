using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{

	public float speed;
	
	[SerializeField]
	private Vector2 moveAreaCenter, moveAreaRange;

	private Vector2 pos;

	void Awake()
	{
		pos = transform.position;
	}
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector2 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		float moveArc = Mathf.Atan2 (mousePos.y - pos.y, mousePos.x - pos.x);

		float moveDistance = (mousePos - pos).magnitude;

		if (moveDistance > speed * Time.deltaTime)
		{
			pos += new Vector2 (Mathf.Cos (moveArc), Mathf.Sin (moveArc)) * speed * Time.deltaTime;
		} else 
		{
			pos = mousePos;
		}

		rangePos ();

		transform.position = pos;
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireCube (moveAreaCenter, moveAreaRange * 2);
		Gizmos.color = Color.white;
	}

	private void rangePos()
	{
		if (pos.x > moveAreaCenter.x + moveAreaRange.x)
		{
			pos.x = moveAreaCenter.x + moveAreaRange.x;
		}else if (pos.x < moveAreaCenter.x - moveAreaRange.x)
		{
			pos.x = moveAreaCenter.x - moveAreaRange.x;
		}
		
		if (pos.y > moveAreaCenter.y + moveAreaRange.y)
		{
			pos.y = moveAreaCenter.y + moveAreaRange.y;
		}else if (pos.y < moveAreaCenter.y - moveAreaRange.y)
		{
			pos.y = moveAreaCenter.y - moveAreaRange.y;
		}
	}
}
