using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Text = TMPro.TextMeshProUGUI;

[System.Serializable]
public struct VecTrack
{
	[Range(-1, 1)]
	public float curva;
	public float distance;

	public VecTrack(float curva, float distance)
	{
		this.curva = curva;
		this.distance = distance;
	}
}



public class RoadRacer : MonoBehaviour
{
	private GameControls gameControls;
	private void Awake()
	{
		gameControls = new GameControls();
	}

	private void OnEnable()
	{
		gameControls.Enable();
	}

	public void OnDisable()
	{
		gameControls.Disable();
	}

	public Transform Car;
	private Vector3 camToCarOffset;
	public Transform[] rivalCar; List<Vector2> defaultRivalCarPoses = new List<Vector2>();
	public List<Transform> rivalCarIn = new List<Transform>();//进入画面的敌方赛车

	public Transform backGround;
	public int screenWeidth = 160, screenHeight = 100;
	public SpriteRenderer pixelPref, treePref;
	public Color grassColor, shouderColor, shouderLowColor, roadColor, roadLowColor, grassLowColor, treeColor, treeLowColor, whitLineColor;

	private GameObject grassHolder, roadShouderHolder, roadHolder, treeHolder, whiteLineHolder;

	//道路 路肩 草地 树木的 初始位置
	private List<Vector2> defaultRoadPoses = new List<Vector2>();
	private List<Vector2> defaultRoadShouderPoses = new List<Vector2>();
	private List<Vector2> defaultWhiteLinePoses = new List<Vector2>();
	private List<Vector2> defaultGrassPoses = new List<Vector2>();
	private List<Vector2> defaultTreePoses = new List<Vector2>();
	//道路 路肩 草地 树木的 初始位置


	private float fCarPos = 0.0f;
	private float fDistance = 0.0f;
	private float fSpeed = 0.0f;

	private float fCurvatrue = 0.0f;  //像素偏移系数 ----> 转弯量
	private float fTranckCurvature = 0.0f;//由弯道弧度，车速度共同决定的离心力
	private float fPlayerCurvature = 0.0f;//玩家对方向控制的系数


	[Header("填入赛道信息参数")]
	public List<VecTrack> vecTrack = new List<VecTrack>();  // curvature,distance，记录赛道信息
	public float sumDistance = 0.0f;

	public List<SpriteRenderer> grassList = new List<SpriteRenderer>();
	public List<SpriteRenderer> roadShouderList = new List<SpriteRenderer>();
	public List<SpriteRenderer> whiteLineList = new List<SpriteRenderer>();
	public List<SpriteRenderer> roadList = new List<SpriteRenderer>();
	public List<SpriteRenderer> treeList = new List<SpriteRenderer>();

	//UI
	public Text gearText, speedText, startTimeCountText, timeText;
	public Image[] speedCountUIBlock, speedCountdisActiveBlock;
	private int speedUICount = 0;
	private int speedUIdisActiveCount = 0;
	private float startTimeCount = 4; // 倒计时
	private float timeCount;//时间限制计数
	public float defaultTimeCount;//时间限制（秒）

	public bool finishTheTrack;
	//UI

	//Sound Effect
	public AudioClip startEngineSound, engineSound;
	public AudioSource AC1, AC2;
	private float pitch;
	public GameObject rivalCarSoundObj;
	//Sound Effect




	// Use this for initialization
	void Start()
	{
		camToCarOffset = Car.position - transform.position;
		startTimeCount = 4;
		timeCount = defaultTimeCount;
		/*赛道信息，弯道弧度，弯道长度，0为直道
		vecTrack.Add(new Vector2(0.0f,100.0f));
		vecTrack.Add(new Vector2(0.0f,200.0f));
		vecTrack.Add(new Vector2(1.0f,500.0f));
		vecTrack.Add(new Vector2(0.0f,400f));
		vecTrack.Add(new Vector2(-1.0f,400f));
		vecTrack.Add(new Vector2(0.5f,2000f));
		vecTrack.Add(new Vector2(-1.0f,400f));
		vecTrack.Add(new Vector2(1.0f,200f));
		vecTrack.Add(new Vector2(0.0f,3000f));
		vecTrack.Add(new Vector2(0.5f,500f));
		vecTrack.Add(new Vector2(0.0f,100));
		vecTrack.Add(new Vector2(0.5f,5000f));
		vecTrack.Add(new Vector2(-0.5f,2000f));
		vecTrack.Add(new Vector2(0.5f,3000f));
		vecTrack.Add(new Vector2(0,2000f));
		vecTrack.Add(new Vector2(0.0f,1000f));
		*/

		//计算总里程
		foreach (VecTrack vec in vecTrack)
		{
			sumDistance += vec.distance;
		}
		//赛道信息，弯道弧度，弯道长度，0为直道



		grassHolder = new GameObject();
		grassHolder.name = "grassHolder";
		roadShouderHolder = new GameObject();
		roadShouderHolder.name = "roadShouderHolder";
		roadHolder = new GameObject();
		roadHolder.name = "roadHolder";
		whiteLineHolder = new GameObject();
		whiteLineHolder.name = "LineHolder";
		treeHolder = new GameObject();
		treeHolder.name = "treeHolder";

		//rivalCar 的默认位置
		for (int i = 0; i < rivalCar.Length; i++)
		{
			defaultRivalCarPoses.Add(rivalCar[i].position);
		}

		//rivalCar 的默认位置

		//绘制行道树
		for (int y = 0; y < screenHeight; y++)
		{
			for (int x = -100; x < screenWeidth + 100; x++)
			{
				float fPerspective = (float)y / (screenHeight / 2.0f);

				float fMiddlepoint = 0.5f;
				float fRoadWidth = -0.05f + fPerspective * 1.2f;
				float fClipWidth = fRoadWidth * 0.15f;
				float fMiddleWidth = fRoadWidth * 0.015f;

				fRoadWidth *= 0.5f;

				float nLeftGrass = (fMiddlepoint - fRoadWidth - fClipWidth) * screenWeidth;
				float nLeftClip = (fMiddlepoint - fRoadWidth) * screenWeidth;
				float nRightClip = (fMiddlepoint + fRoadWidth) * screenWeidth;
				float nRightGrass = (fMiddlepoint + fRoadWidth + fClipWidth) * screenWeidth;

				int nRow = screenHeight / 2 + y;
				Color nTreeColor = Mathf.Sin(100f * Mathf.Pow(1.0f - fPerspective, 3) + fDistance * 0.1f) > 0.0f ? treeColor : treeLowColor;


				if ((x >= nLeftClip - 20 && x < nLeftClip - 19) || (x <= nRightClip + 20 && x > nRightClip + 19))
				{
					SpriteRenderer treeTemp = (SpriteRenderer)Instantiate(treePref, new Vector3(x, nRow), Quaternion.identity); treeTemp.color = nTreeColor;
					treeTemp.transform.parent = treeHolder.transform;
					treeList.Add(treeTemp);
					defaultTreePoses.Add(treeTemp.transform.position);
					treeTemp.transform.localScale = new Vector2(2 * Mathf.Pow(-1.0f + fPerspective, 3) + 3, 2 * Mathf.Pow(-1.0f + fPerspective, 3) + 3);
				}
			}
		}
		//绘制行道树


		//绘制路，路肩，草地
		for (int y = 0; y < 2 * screenHeight / 3; y++)
		{
			for (int x = -100; x < screenWeidth + 100; x++)
			{
				float fPerspective = (float)y / (screenHeight / 2.0f);

				float fMiddlepoint = 0.5f;
				float fRoadWidth = 0.05f + fPerspective * 1.2f;
				float fClipWidth = fRoadWidth * 0.12f;
				float fMiddleWidth = fRoadWidth * 0.015f;

				fRoadWidth *= 0.5f;

				float nLeftGrass = (fMiddlepoint - fRoadWidth - fClipWidth) * screenWeidth;
				float nLeftClip = (fMiddlepoint - fRoadWidth) * screenWeidth;
				float nLeftMiddleClip = (fMiddlepoint - fMiddleWidth) * screenWeidth;
				float nRightMiddleClip = (fMiddlepoint + fMiddleWidth) * screenWeidth;
				float nRightClip = (fMiddlepoint + fRoadWidth) * screenWeidth;
				float nRightGrass = (fMiddlepoint + fRoadWidth + fClipWidth) * screenWeidth;

				int nRow = screenHeight / 2 + y;

				Color nGrassColor = Mathf.Sin(20.0f * Mathf.Pow(1.0f - fPerspective, 3) + fDistance * 0.1f) > 0.0f ? grassColor : grassLowColor;



				if (x >= -1000 && x < nLeftGrass)
				{
					SpriteRenderer grassPixTemp = (SpriteRenderer)Instantiate(pixelPref, new Vector3(x, nRow), Quaternion.identity); grassPixTemp.color = nGrassColor;
					grassPixTemp.transform.parent = grassHolder.transform;
					grassList.Add(grassPixTemp);
					defaultGrassPoses.Add(grassPixTemp.transform.position);
				}
				if (x >= nLeftGrass && x < nLeftClip)
				{
					SpriteRenderer roadShouderPixTemp = (SpriteRenderer)Instantiate(pixelPref, new Vector3(x, nRow), Quaternion.identity); roadShouderPixTemp.color = shouderColor;
					roadShouderPixTemp.transform.parent = roadShouderHolder.transform;
					roadShouderList.Add(roadShouderPixTemp);
					defaultRoadShouderPoses.Add(roadShouderPixTemp.transform.position);
				}

				/*Road And Line*/
				if (x >= nLeftClip && x < nLeftMiddleClip)
				{
					SpriteRenderer roadPixLeftTemp = (SpriteRenderer)Instantiate(pixelPref, new Vector3(x, nRow), Quaternion.identity); roadPixLeftTemp.color = roadColor;
					roadPixLeftTemp.transform.parent = roadHolder.transform;
					roadList.Add(roadPixLeftTemp);
					defaultRoadPoses.Add(roadPixLeftTemp.transform.position);
				}
				if (x >= nLeftMiddleClip && x < nRightMiddleClip)
				{
					SpriteRenderer linePixLeftTemp = (SpriteRenderer)Instantiate(pixelPref, new Vector3(x, nRow), Quaternion.identity); linePixLeftTemp.color = whitLineColor;
					linePixLeftTemp.transform.parent = whiteLineHolder.transform;
					whiteLineList.Add(linePixLeftTemp);
					defaultWhiteLinePoses.Add(linePixLeftTemp.transform.position);
				}
				if (x >= nRightMiddleClip && x < nRightClip)
				{
					SpriteRenderer roadPixLeftTemp = (SpriteRenderer)Instantiate(pixelPref, new Vector3(x, nRow), Quaternion.identity); roadPixLeftTemp.color = roadColor;
					roadPixLeftTemp.transform.parent = roadHolder.transform;
					roadList.Add(roadPixLeftTemp);
					defaultRoadPoses.Add(roadPixLeftTemp.transform.position);
				}
				/*Road And Line*/

				if (x >= nRightClip && x < nRightGrass)
				{
					SpriteRenderer roadShouderPixTemp = (SpriteRenderer)Instantiate(pixelPref, new Vector3(x, nRow), Quaternion.identity); roadShouderPixTemp.color = shouderColor;
					roadShouderPixTemp.transform.parent = roadShouderHolder.transform;
					roadShouderList.Add(roadShouderPixTemp);
					defaultRoadShouderPoses.Add(roadShouderPixTemp.transform.position);
				}
				if (x >= nRightGrass && x < screenWeidth + 1000)
				{
					SpriteRenderer grassPixTemp = (SpriteRenderer)Instantiate(pixelPref, new Vector3(x, nRow), Quaternion.identity); grassPixTemp.color = nGrassColor;
					grassPixTemp.transform.parent = grassHolder.transform;
					//if(x >= nRightGrass && x < screenWeidth)
					//{
					grassList.Add(grassPixTemp);
					defaultGrassPoses.Add(grassPixTemp.transform.position);
					//}
				}
			}
		}

		StartCoroutine(StartTimeCount());
		//StartCoroutine(TimeCount());

		//引擎发动声效
		//AC1.PlayOneShot(startEngineSound);
		//AC2.clip = engineSound;
		//AC2.Play ();
		//引擎发动声效
	}
	//绘制路，路肩，草地


	//开始倒计时

	IEnumerator StartTimeCount()
	{
		for (int i = 0; i < 5; i++)
		{
			startTimeCount = Mathf.Clamp(startTimeCount, -1f, 4);
			if (startTimeCount > -1f)
			{
				startTimeCount -= 1;
				//startTimeCountText.text = startTimeCount < 0? "" : startTimeCount.ToString("f0");
				yield return new WaitForSeconds(1f);
			}
		}
		yield return null;
	}
	//开始倒计时

	//倒计时
	IEnumerator TimeCount()
	{
		for (int i = 0; i < defaultTimeCount + 5; i++)
		{
			timeCount = Mathf.Clamp(timeCount, -1, timeCount + 1);

			if (timeCount > -1f && !finishTheTrack)
			{
				if (startTimeCount < 0)
				{
					timeCount -= 1;
					timeText.text = timeCount < 0 ? "\r\n" + "\r\n" + "\r\n" + "Time's Up" : timeCount.ToString("f0");
				}
				else if (startTimeCount == 0)
				{
					timeText.text = "Start";
				}
				else if (startTimeCount > 0)
				{
					timeText.text = "Ready";
				}
				yield return new WaitForSeconds(1f);
			}
			else if (finishTheTrack)
			{
				timeText.text = "\r\n" + "\r\n" + "\r\n" + "FINISH";
			}
		}
	}
	//倒计时




	// Update is called once per frame
	public bool topGear = false;

	void Update()
	{
		fSpeed += topGear ? 0.1f * Time.deltaTime : 2.0f * Time.deltaTime;
		Vector2 movementInput = gameControls.Move.Directions.ReadValue<Vector2>();
		/*if (Input.GetKey (KeyCode.W)) 
		{
			//fDistance += 20.0f;   //汽车行驶的距离
			if(startTimeCount < 0&&!finishTheTrack && timeCount>-1f && !Car.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("CarExpolosion"))
			{
				fSpeed += topGear? 0.1f * Time.deltaTime : 2.0f * Time.deltaTime; 
			}
			else if(timeCount <= -1)
			{
				fSpeed -= 0.8f * Time.deltaTime;
			}
		}
		else
		{
			fSpeed -= 0.8f * Time.deltaTime;
		}*/
			

		if(movementInput.x == -1 && !finishTheTrack &&startTimeCount < 0 && timeCount > -1f && 
			!Car.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("CarExpolosion"))
		{
			fPlayerCurvature += 0.7f * Time.deltaTime;
		}

		if(movementInput.x == 1 && !finishTheTrack &&startTimeCount < 0 && timeCount > -1f && 
			!Car.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("CarExpolosion"))
		{
			fPlayerCurvature -= 0.7f * Time.deltaTime;
		}

		/*if (Input.GetKeyDown (KeyCode.RightShift)) 
		{
			//Change The gear
			topGear = !topGear;
			gearText.text = topGear? "High" : "Low";
		}*/



		if (Mathf.Abs(fPlayerCurvature - 0.2f - fTranckCurvature) >= 0.8f) //0.2f 用来修正判定偏右，不等式右边越大，可行驶的道路宽度越宽
		{
			fSpeed -= 5.0f * Time.deltaTime; //赛车到道路边缘 停下
		}



		//Switch The Gear ,Clamp the speed
		float gearSpeed = topGear ? 1.8f : 1.0f;

		if (fSpeed < 0.0f)
		{
			fSpeed = 0.0f;
		}
		if (fSpeed > gearSpeed)
		{
			fSpeed = Mathf.Lerp(fSpeed, 1.0f, 5 * Time.deltaTime);
		}

		//Switch The Gear, Clamp The Speed


		//Engine Sound According The fSpeed
		pitch = topGear ? fSpeed / gearSpeed + 0.5f : fSpeed / gearSpeed - 0.3f;
		//AC2.pitch = pitch;
		//Engine Sound According The fSpeed



		//Move Car alone track according to car speed
		if (startTimeCount < 0 && timeCount > -1 && !Car.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("CarExpolosion"))
		{
			fDistance += (300f * fSpeed) * Time.deltaTime;
		}


		//UI Control
		/*if(startTimeCount < 0)
		{
			speedText.text = (Mathf.Clamp((300f * fSpeed - 100f),0f,360f)).ToString ("f0") + "KM / H";
		}*/

		/*speedUICount = (int)Mathf.Clamp ((300f * fSpeed - 100f), 0f, 360f) / 40;
		speedUIdisActiveCount = speedCountUIBlock.Length - speedUICount;
		for(int i = 0; i < speedUICount; i++)
		{
			if(speedUICount > 0)
			{
				speedCountUIBlock[i].enabled = true;
			}
		}
		for(int i = 0; i < speedUIdisActiveCount; i++)
		{
			if(speedUIdisActiveCount > 0)
			{
				speedCountdisActiveBlock[i].enabled = false;
			}
		}*/
		//UI Control




		//get point On Track
		float fOffset = 0;
		int nTrackSection = 0;

		//Find position On track
		while (nTrackSection < vecTrack.Count && fOffset <= fDistance)
		{
			fOffset += vecTrack[nTrackSection].distance;
			nTrackSection++;
		}

		float fTargetCurvature = vecTrack[nTrackSection - 1].curva;

		float fTrackCurveDiff = (fTargetCurvature - fCurvatrue) * Time.deltaTime * fSpeed;
		fCurvatrue += fTrackCurveDiff;//  像素偏移系数 ----> 转弯量

		//float fMiddlepoint = 0.5f + fCurvatrue;//貌似这句不参与计算

		fTranckCurvature += (fCurvatrue) * Time.deltaTime * fSpeed; // 速度，和道路弯度 共同决定弯道对赛车的离心力 





		for (int i = 0; i < grassList.Count; i++)
		{
			float fPerspective = (float)(grassList[i].transform.position.y - screenHeight / 2) / (screenHeight / 2.0f);     // y = nRow - screenHeight/2
			grassList[i].color = Mathf.Sin(10.0f * Mathf.Pow(1.0f - fPerspective, 3) + fDistance * 0.1f) < 0.0f ? grassColor : grassLowColor;
			grassList[i].transform.position = new Vector2(defaultGrassPoses[i].x + (fCurvatrue * Mathf.Pow(1.0f - fPerspective, 3)) * screenWeidth, grassList[i].transform.position.y);
		}
		for (int i = 0; i < roadShouderList.Count; i++)
		{
			float fPerspective = (float)(roadShouderList[i].transform.position.y - screenHeight / 2) / (screenHeight / 2.0f);     //y = nRow - screenHeight/2
			roadShouderList[i].color = Mathf.Sin(15.0f * Mathf.Pow(1.0f - fPerspective, 3) + fDistance * 0.1f) < 0.0f ? shouderColor : shouderLowColor;
			roadShouderList[i].transform.position = new Vector2(defaultRoadShouderPoses[i].x + (fCurvatrue * Mathf.Pow(1.0f - fPerspective, 3)) * screenWeidth, roadShouderList[i].transform.position.y);
		}
		for (int i = 0; i < roadList.Count; i++)
		{
			float fPerspective = (float)(roadList[i].transform.position.y - screenHeight / 2) / (screenHeight / 2.0f);
			roadList[i].color = Mathf.Sin(29.0f * Mathf.Pow(1.0f - fPerspective, 3) + fDistance * 0.1f) < 0.0f ? roadLowColor : roadColor;
			roadList[i].transform.position = new Vector2(defaultRoadPoses[i].x + (fCurvatrue * Mathf.Pow(1.0f - fPerspective, 3)) * screenWeidth, roadList[i].transform.position.y);
		}
		for (int i = 0; i < whiteLineList.Count; i++)
		{
			float fPerspective = (float)(whiteLineList[i].transform.position.y - screenHeight / 2) / (screenHeight / 2.0f);
			whiteLineList[i].color = Mathf.Sin(29.0f * Mathf.Pow(1.0f - fPerspective, 3) + fDistance * 0.1f) < 0.0f ? whitLineColor : roadColor;
			whiteLineList[i].transform.position = new Vector2(defaultWhiteLinePoses[i].x + (fCurvatrue * Mathf.Pow(1.0f - fPerspective, 3)) * screenWeidth, whiteLineList[i].transform.position.y);
		}

		for (int i = 0; i < treeList.Count; i++)
		{
			float fPerspective = (float)(treeList[i].transform.position.y - screenHeight / 2) / (screenHeight / 2.0f);
			treeList[i].color = Mathf.Sin(100.0f * Mathf.Pow(1.0f - fPerspective, 3) + fDistance * 0.1f) < 0.0f ? treeColor : treeLowColor;
			treeList[i].transform.position = new Vector2(defaultTreePoses[i].x + (fCurvatrue * Mathf.Pow(1.0f - fPerspective, 3)) * screenWeidth, treeList[i].transform.position.y);
		}


		//Pos The Car
		fCarPos = fPlayerCurvature - fTranckCurvature; // 玩家的控制， 车速度，和道路弯度 决定 赛车偏移量
		int nCarPos = screenWeidth / 2 + ((int)(screenWeidth * fCarPos) / 2) - 7;
		Car.position = new Vector2(nCarPos, Car.position.y);




		//Pos The Rival Car
		if (startTimeCount < 0 && !finishTheTrack)
		{
			for (int i = 0; i < rivalCar.Length; i++)
			{
				float fRivalPerspective = (float)(rivalCar[i].transform.position.y - screenHeight / 2) / (screenHeight / 2.0f);
				float fRivalCarPosY = fSpeed > 0 ? rivalCar[i].position.y + 10 * fSpeed * Time.deltaTime : rivalCar[i].position.y - 40 * Time.deltaTime;
				rivalCar[i].transform.position = new Vector2(defaultRivalCarPoses[i].x + (fCurvatrue * Mathf.Pow(1.0f - fRivalPerspective, 3)) * screenWeidth, fRivalCarPosY);

				if (rivalCar[i].transform.position.x < 150 &&
				   rivalCar[i].transform.position.x > 2 &&
				   rivalCar[i].transform.position.y < 103 &&
				   rivalCar[i].transform.position.y > 6)
				{//在画面内才能进行缩放
					rivalCar[i].transform.localScale = new Vector2(0.9f - 1 * Mathf.Pow(-1.0f + fRivalPerspective, 2), 0.9f - 1 * Mathf.Pow(-1.0f + fRivalPerspective, 2));

					if (rivalCar[i].transform.transform.localScale.x < 0)
					{
						rivalCar[i].GetComponent<SpriteRenderer>().enabled = false;
					}
					else
					{
						rivalCar[i].GetComponent<SpriteRenderer>().enabled = true;
					}


					if (!rivalCarIn.Contains(rivalCar[i]))           // 敌车进入画面，添加那辆敌车到列表，否则移除它
					{
						rivalCarIn.Add(rivalCar[i]);                  // 敌车进入画面，添加那辆敌车到列表，否则移除它
					}
				}
				else if (rivalCar[i].transform.position.x > 150 ||
					rivalCar[i].transform.position.x < 2 ||
					rivalCar[i].transform.position.y > 103 ||
					rivalCar[i].transform.position.y < 6)
				{
					if (rivalCarIn.Contains(rivalCar[i]))
					{
						rivalCarIn.Remove(rivalCar[i]);
					}
				}
			}
		}

		/*if (rivalCarIn.Count != 0)  //判断是否有敌车在画面里面(列表是否为空)，如果有，激活敌车音效对象
		{  
			rivalCarSoundObj.SetActive (true);
		} 
		else if(rivalCarIn.Count == 0)
		{
			rivalCarSoundObj.SetActive (false);
		}*/
		//Pos The Rival Car


		//判断是否撞车
		for (int i = 0; i < rivalCar.Length; i++)
		{
			if (Mathf.Abs(rivalCar[i].transform.position.x - Car.transform.position.x) < 8f)
			{
				if (Mathf.Abs(rivalCar[i].transform.position.y - Car.transform.position.y) < 8f)
				{
					if (Car.GetComponent<CarAnimEvent>().canExplosion == true)
					{
						Car.GetComponent<Animator>().SetTrigger("Exlosion");
					}
					//Debug.Log (Mathf.Abs (rivalCar [i].transform.position.x - Car.transform.position.x));
				}
			}

		}

		if (Car.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("CarExpolosion"))
		{
			fSpeed = 0;
		}
		//判断是否撞车


		//车的转向动画控制
		Car.GetComponent<Animator>().SetInteger("InputH", (int)(vecTrack[nTrackSection - 1].curva * 10));
		for (int i = 0; i < rivalCar.Length; i++)
		{
			rivalCar[i].GetComponent<Animator>().SetInteger("InputH", (int)(vecTrack[nTrackSection - 1].curva * 10));
		}


		//背景图层的视差卷轴效果
		if (timeCount > -1)
		{
			backGround.transform.position = new Vector3(backGround.transform.position.x - vecTrack[nTrackSection - 1].curva * fSpeed, backGround.transform.position.y - fDistance / 500000 * fSpeed);
		}

		//roadHolder.transform.position = new Vector2(defaultRoadHolderPos.x + fCurvatrue*screenWeidth,roadHolder.transform.position.y); 
		//roadShouderHolder.transform.position = new Vector2(defaultRoadShouderHolderPos.x + fCurvatrue *screenWeidth, roadShouderHolder.transform.position.y);
		//grassHolder.transform.position = new Vector2(defaultGrassHolderPos.x + fCurvatrue* screenWeidth,grassHolder.transform.position.y);
		//Debug.Log(fCurvatrue * 1000);


		//判断是否到达终点
		if (fDistance > sumDistance - 200)
		{
			finishTheTrack = true;
			fSpeed -= 2.0f * Time.deltaTime;
			Car.GetComponent<Animator>().SetBool("Finish", finishTheTrack);
		}




		////控制摄像机跟随
		///This code makes the camera follow the player
		Vector3 targetPos = Vector3.Lerp(transform.position, Car.position, Time.deltaTime * 0.2f) - camToCarOffset;
		//transform.position = new Vector3(targetPos.x, transform.position.y, -10);


		////控制摄像机跟随
	}

}
