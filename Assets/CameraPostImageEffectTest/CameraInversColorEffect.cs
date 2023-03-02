using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInversColorEffect : MonoBehaviour 
{
	public Material inverseColorMat;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnRenderImage(RenderTexture src, RenderTexture des)
	{
		Graphics.Blit(src,des,inverseColorMat);
	}
}
