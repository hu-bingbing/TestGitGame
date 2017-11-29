
using UnityEngine;
using System.Collections;

//	地图块类型
public enum BlockTypes {
	None = 0,	//	空
	Brick,		//	砖块
	Steel,		//	铁块
	Water,		//	水
	Forest,		//	森林
}

//	Cell 在 Block 中的方向
public enum CellDirections {
	LeftUp = 1 << 0,	//	左上角
	RightUp = 1 << 1,	//	右上角
	LeftDown = 1 << 2,	//	左下角
	RightDown = 1 << 3,	//	右下角
	Left = LeftUp | LeftDown,		//	左侧
	Right = RightUp | RightDown,	//	右侧
	Up = LeftUp | RightUp,			//	上方
	Down = LeftDown | RightDown,	//	下方
	All = Left | Right,	//	全部
}

public class BlockModel {

	public BlockTypes type;	//	地图块类型
	public CellDirections direction;	//	Cell 在 Block 中的方向	
	public Vector2 pos;	//	地图块在整个地图中的相对位置

	//	构造函数
	public BlockModel (BlockTypes type, CellDirections direction, Vector2 pos) {
		Init (type, direction, pos);
	}

	//	构造函数
	public BlockModel (BlockModel m) {
		Init (m.type, m.direction, m.pos);
	}
	
	//	指定初始化方法
	private void Init (BlockTypes type, CellDirections direction, Vector2 pos) {
		//	初始化成员变量
		this.type = type;
		this.direction = direction;
		this.pos = pos;
	}
}
