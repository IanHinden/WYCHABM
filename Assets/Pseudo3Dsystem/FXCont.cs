using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum FXS{None,CRT,Inverscolor};

public class FXCont : MonoBehaviour 
{
	public CameraInversColorEffect FX1;
	public Camera mainCam;
	public RenderTexture FX2RenderTexure;

	public FXS currentFX;
	public int fxIndex = 0;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		fxIndex = Mathf.Clamp(fxIndex,0,3);
		/*if(Input.GetKeyDown(KeyCode.LeftShift))
		{
			fxIndex += 1;
			//mainCam.targetTexture = null;
			//FX1.enabled = true;
			if(fxIndex == 3)
			{
				fxIndex = 0;
			}
		}*/
		currentFX = (FXS)fxIndex;

		switch (currentFX) 
		{
		case FXS.None :
			mainCam.targetTexture = null;
			FX1.enabled = false;
			break;

		case FXS.CRT:
			mainCam.targetTexture =  FX2RenderTexure;
			FX1.enabled = false;
			break;

		case FXS.Inverscolor:
			mainCam.targetTexture = null;
			FX1.enabled = true;
			break;
		}

	}
}
