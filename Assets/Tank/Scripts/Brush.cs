
using UnityEngine;
using System.Collections;

public class Brush : MonoBehaviour {

	private BlockModel model;	//	笔刷的数据模型
	private BlockController bc;	//	笔刷上的控制器
	//	笔刷相对位置
	private int w;
	private int h;

	void Awake () {
		//	初始化成员变量
		model = new BlockModel (BlockTypes.Brick, CellDirections.All, Vector2.zero);
		bc = GetComponent <BlockController> ();
	}

	void Start () {
		//	刷新笔刷
		bc.Reflash (model);
	}
	
	void Update () {
		//	更新笔刷位置
		UpdatePos ();
		//	监听用户事件
		EventListener ();
	}

	private int tempW;
	private int tempH;

	//	更新笔刷位置
	private void UpdatePos () {
		//	计算笔刷绝对位置
		Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		pos.z = 0f;
		//	修正鼠标位置
		pos.x += Global.blockSize / 2f;
		pos.y -= Global.blockSize / 2f;
		//	计算出笔刷的相对位置
		tempW = (int)((pos.x - (1 - Global.mapWidth) / 2f * Global.blockSize) / Global.blockSize);
		tempH = (int)(((Global.mapHeight - 1) / 2f * Global.blockSize - pos.y) / Global.blockSize);
		//	根据相对位置刷新笔刷位置
		if (tempW >= 0 && tempW < Global.mapWidth && tempH >= 0 && tempH < Global.mapHeight) {
			//	更新 w 和 h 的值
			w = tempW;
			h = tempH;
			//	计算笔刷位置
			float x = (1 - Global.mapWidth) / 2f * Global.blockSize + w * Global.blockSize;;
			float y = (Global.mapHeight - 1) / 2f * Global.blockSize - h * Global.blockSize;
			Vector3 brushPos = new Vector3 (x, y, 0f);
			//	更新笔刷位置
			transform.position = brushPos;
		}
	}

	//	监听用户事件
	private void EventListener () {
		//	检测用户是否按下鼠标左键
		if (Input.GetMouseButtonDown (0)) {
			//	如果鼠标当前在地图范围内
			if (tempW >= 0 && tempW < Global.mapWidth && tempH >= 0 && tempH < Global.mapHeight) {
				//	更新界面和数据模型
				GameObject.FindGameObjectWithTag ("Map").GetComponent <Map> ().ReflashBlock (model, w, h);
			}
		}
		//	检测用户是否按下鼠标右键
		if (Input.GetMouseButtonDown (1)) {
			//	修改 Block 的类型
			if (model.type == BlockTypes.Forest) {
				model.type = BlockTypes.None;
			} else {
				model.type++;
			}
			//	刷新笔刷的显示
			bc.Reflash ();
		}
		//	改变地图块中 Cell 的方向
		float ms = Input.GetAxis ("Mouse ScrollWheel");
		if (ms > 0f) {
			//	修改 Block 中 Cell 的方向
			if (model.direction == CellDirections.All) {
				model.direction = CellDirections.LeftUp;
			} else {
				model.direction++;
			}
			//	刷新笔刷的显示
			bc.Reflash ();
		}
		if (ms < 0f) {
			//	修改 Block 中 Cell 的方向
			if (model.direction == CellDirections.LeftUp) {
				model.direction = CellDirections.All;
			} else {
				model.direction--;
			}
			//	刷新笔刷的显示
			bc.Reflash ();
		}
	}
}
