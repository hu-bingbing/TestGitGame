
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapList {

	public Dictionary <string, BlockModel [,]> maps;	//	游戏中所有地图
	public string loadMapName = "";

	private static MapList instance = null;	//	单例实例

	//	获取单例实例
	public static MapList GetInstnce () {
		if (instance == null) {
			instance = new MapList ();
		}
		return instance;
	}

	//	私有化默认构造
	private MapList () {
		//	初始化成员变量
		maps = new Dictionary <string, BlockModel [,]> ();
	}
}
