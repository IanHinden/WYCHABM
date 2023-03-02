using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAnimEvent : MonoBehaviour 
{
	public Transform Cam;
	public bool canExplosion = true;
	void LeftCamEvent()
	{
		Cam.transform.eulerAngles = new Vector3(0,0,7);
	}
	void LeftMidCamEvent()
	{
		Cam.transform.eulerAngles = new Vector3(0,0,3);
	}
	void RightCamEvent()
	{
		Cam.transform.eulerAngles = new Vector3(0,0,-7);
	}
	void RightMidCamEvent()
	{
		Cam.transform.eulerAngles = new Vector3(0,0,-3);
	}
	void DefaultCamEvent()
	{
		Cam.transform.eulerAngles = new Vector3(0,0,0);
	}

	void CanExplosion()
	{
		canExplosion = true;
	}
	void FalseExplosion()
	{
		canExplosion = false;
	}
}
