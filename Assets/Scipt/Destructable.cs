using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

[Serializable]
public class floatEvent: UnityEvent<float>{}

public class Destructable : MonoBehaviour
{
	[SerializeField]
	private float _maxHp;
	private float _hp;
	public floatEvent hpChanged;
	public UnityEvent OnDie;

	public float hp
	{
		set
		{
			_hp = Mathf.Min(value, maxHp);
			hpChanged.Invoke(_hp/maxHp);
			if(_hp <= 0)
			{
				OnDie.Invoke();
			}
		}
		get
		{
			return _hp;
		}
	}

	public float maxHp
	{
		set
		{
			_maxHp = value;
			hp = hp;
		}
		get
		{
			return _maxHp;
		}
	}

	void Start ()
	{
		_hp = _maxHp;
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
}
