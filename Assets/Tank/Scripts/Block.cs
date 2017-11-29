
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Block : MonoBehaviour {

	public GameObject brick;	//	砖块预设体
	public GameObject steel;	//	铁块预设体
	public GameObject forest;	//	森林预设体
	public GameObject water;	//	水预设体
	public BlockModel model;	//	数据模型

	private Dictionary <BlockTypes, GameObject> prefabs;	//	预设体容器
	private GameObject [,] cells;	//	当前地形块中的 Cell
	private BlockTypes lastType;	//	最后一次更新 Block 时地图块的类型

	void Awake () {
		//	初始化成员变量
		prefabs = new Dictionary <BlockTypes, GameObject> ();
		cells = new GameObject [2, 2];
		lastType = BlockTypes.None;
		//	把预设体存入容器
		prefabs.Add (BlockTypes.Brick, brick);
		prefabs.Add (BlockTypes.Steel, steel);
		prefabs.Add (BlockTypes.Forest, forest);
		prefabs.Add (BlockTypes.Water, water);
	}

	//	更新地图块
	public void UpdateBlock () {
		//	判断数据模型是否存在
		if (model != null) {
			if (model.type != lastType) {
				//	清除当前所有的 Cell
				ClearCell ();
				//	根据模型类型重新创建对应的 Cell
				if (model.type != BlockTypes.None) {
					//	创建所有 Cell
					CreateCell (prefabs [model.type]);
				}
				//	更新最后一次刷新类型
				lastType = model.type;
			}
			//	去掉不显示的 Cell
			SetCellDirection ();
		}
	}

	//	清除当前所有的 Cell
	private void ClearCell () {
		//	遍历整个 Cells 数组
		for (int i = 0;i < 2;i++) {
			for (int j = 0;j < 2;j++) {
				//	如果对应的位置存在 Cell 则销毁
				if (cells [i, j] != null) {
					//	销毁 Cell
					Destroy (cells [i, j]);
					//	数组置为空
					cells [i, j] = null;
				}
			}	
		}
	}

	//	设置 Cell 的方向
	private void SetCellDirection () {
		//	判断当前 Block 类型是否为空
		if (model.type != BlockTypes.None) {
			//	检测 Block 中是否包含左上角的 Cell
			if ((model.direction & CellDirections.LeftUp) != 0) {
				cells [0, 0].SetActive (true);
			} else {
				cells [0, 0].SetActive (false);
			}
			//	检测 Block 中是否包含右上角的 Cell
			if ((model.direction & CellDirections.RightUp) != 0) {
				cells [1, 0].SetActive (true);
			} else {
				cells [1, 0].SetActive (false);
			}
			//	检测 Block 中是否包含左下角的 Cell
			if ((model.direction & CellDirections.LeftDown) != 0) {
				cells [0, 1].SetActive (true);
			} else {
				cells [0, 1].SetActive (false);
			}
			//	检测 Block 中是否包含右下角的 Cell
			if ((model.direction & CellDirections.RightDown) != 0) {
				cells [1, 1].SetActive (true);
			} else {
				cells [1, 1].SetActive (false);
			}
		}
	}

	//	创建 Cell
	private void CreateCell (GameObject pre) {
		//	创建出 2×2 的 Cell
		for (int i = 0;i < 2;i++) {
			for (int j = 0;j < 2;j++) {
				//	计算 Cell 位置
				float x = Global.cellSize * (i - 1f / 2f);
				float y = Global.cellSize * (1f / 2f - j);
				Vector3 pos = new Vector3 (x, y, 0f);
				//	计算出世界坐标
				pos += transform.position;
				//	创建 Cell
				GameObject c = Instantiate (pre, pos, Quaternion.identity) as GameObject;
				//	设置 Cell 的父对象
				c.transform.parent = transform;
				//	保存创建的 Cell
				cells [i, j] = c;
			}
		}
	}
}
