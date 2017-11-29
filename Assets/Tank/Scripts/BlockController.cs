
using UnityEngine;
using System.Collections;

public class BlockController : MonoBehaviour {

	public BlockModel model;	//	数据模型

	//	刷新
	public void Reflash (BlockModel m = null) {
		if (m != null) {
			//	更新数据模型
			model = m;
			block.model = model;
		}
		//	刷新地图块
		block.UpdateBlock ();
	}

	private Block block;		//	当前游戏对象上的 Block 脚本

	void Awake () {
		//	初始化成员变量
		block = GetComponent <Block> ();
	}
}
