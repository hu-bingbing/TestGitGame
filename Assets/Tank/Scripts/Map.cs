
using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

	public BlockModel [,] models;	//	地图快数据模型数组
	public GameObject blockPrefab;	//	地图块预设体
	public GameObject bg;	//	地图背景

	//	刷新地图块
	public void ReflashBlock (BlockModel m, int x, int y) {
		//	更新对应位置的数据模型
		models [x, y].type = m.type;
		models [x, y].direction = m.direction;
		//	刷新对应位置的地图块
		blockControllers [x, y].Reflash ();
	}

	private BlockController [,] blockControllers;	//	地图块控制器数组

	void Awake () {
		LoadData ();
		SetupView ();
	}

	//	加载数据
	private void LoadData () {
		//	初始化成员变量
		models = new BlockModel [Global.mapWidth, Global.mapHeight];
		//	获取地图列表
		MapList ml = MapList.GetInstnce ();
        Debug.Log(ml.loadMapName);
		//	如果用户指定了某张地图
		if (ml.loadMapName != "") {
			//	加载指定的地图
			BlockModel [,] bb = ml.maps [ml.loadMapName];
			for (int i = 0;i < Global.mapWidth;i++) {
				for (int j = 0;j < Global.mapHeight;j++) {
					BlockModel tempModel = bb [i, j];
					BlockModel m = new BlockModel (tempModel);
					models [i, j] = m;
				}
			}
		} else {
			//	给数组进行赋值
			for (int i = 0;i < Global.mapWidth;i++) {
				for (int j = 0;j < Global.mapHeight;j++) {
					//	创建数据模型并加入数组
					BlockModel model = new BlockModel (BlockTypes.None, CellDirections.All, new Vector2 (i, j));
					models [i, j] = model;
				}
			}
		}
	}

	//	加载界面
	private void SetupView () {
		//	设置背景和摄像机大小
		bg.transform.localScale = new Vector3 (Global.mapWidth * 2f, Global.mapHeight * 2f, 0f);
		Camera.main.orthographicSize = Global.mapHeight * Global.blockSize / 2f;
		//	初始化成员变量
		blockControllers = new BlockController [Global.mapWidth, Global.mapHeight];
		//	创建地图块
		for (int i = 0;i < Global.mapWidth;i++) {
			for (int j = 0;j < Global.mapHeight;j++) {
				//	计算地图块位置
				float x = (1 - Global.mapWidth) / 2f * Global.blockSize + i * Global.blockSize;
				float y = (Global.mapHeight - 1) / 2f * Global.blockSize - j * Global.blockSize;
				Vector3 pos = new Vector3 (x, y, 0f);
				pos += transform.position;
				//	创建地图块游戏对象
				GameObject block = Instantiate (blockPrefab, pos, Quaternion.identity) as GameObject;
				//	设置地图块的父对象为当前游戏对象
				block.transform.parent = transform;
				//	获取地图块上的控制器
				BlockController bc = block.GetComponent <BlockController> ();
				//	给地图块提供数据模型
				bc.Reflash (models [i, j]);
				//	把控制器存入数组
				blockControllers [i, j] = bc;
			}
		}
	}
}
