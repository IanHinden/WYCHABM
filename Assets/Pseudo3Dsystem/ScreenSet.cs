using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSet : MonoBehaviour 
{

	void Awake()
	{
		Application.targetFrameRate = 60;
		Screen.SetResolution(640, 400, false);
	}

	void Update()
	{
		//  按ESC退出全屏
		/*if (Input.GetKey(KeyCode.Escape))
		{
			Screen.fullScreen = false;  //退出全屏         
		}
		//设置为1080*720不全屏
		if (Input.GetKey(KeyCode.Escape))
		{
			Screen.SetResolution(640, 400, false);
		}
		//设置1080*720的全屏
		if (Input.GetKey(KeyCode.RightControl))
		{
			Screen.SetResolution(640, 400, true);
		}
		//if (Input.GetKey(KeyCode.A))
		//{
			//Resolution[] resolutions = Screen.resolutions;//获取设置当前屏幕分辩率
			//Screen.SetResolution(resolutions[resolutions.Length - 1].width, resolutions[resolutions.Length - 1].height, true);//设置当前分辨率
			//Screen.fullScreen = true;  //设置成全屏,
		//}*/
	}
		
}
