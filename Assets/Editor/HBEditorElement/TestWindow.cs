
using HBEditorElement;
using UnityEditor;
using UnityEngine;

/**	
 *	1. 首先, 每当需要一个新的编辑器窗口, 都需要创建一个新的类, 并继承于 HBWindow;
 *	2. 其次, 这个新创建的类中必须有一个 static 方法, 并添加特性 [MenuItem ("")];
 *	3. 再次, 在静态方法中创建当前类的实例对象, 并调用 Show () 进行显示;
 *	4. 最后, 重写父类的 LayoutSubviews () 方法, 在其中布局整个视图.
 */
public class TestWindow : HBWindow {

	[MenuItem ("Window/Test")]
	public static void ShowWindow () {
		TestWindow t = new TestWindow ();
		t.Show ("Test Window");
	}

	/// <summary>
	/// 布局子视图
	/// 虚方法, 需要在子类中重写
	/// </summary>
	protected override void LayoutSubviews () {
		//	初始化标签 l1 - 文本内容为 "倚天剑", 自动布局
		l1 = new HBLabel ("倚天剑");
		//	设置字体颜色 - 红色
		l1.FontColor = Color.red;
		//	设置对齐方式 - 水平居中并且垂直居中
		l1.Alignment = TextAnchor.MiddleCenter;
		//	设置字体大小 - 32
		l1.FontSize = 32;
		//	启用阴影
		l1.useShadow = true;
		//	设置阴影颜色 - 黑色
		l1.ShadowColor = Color.black;
		//	设置阴影偏移量 - 2
		l1.shadowOffset = 2f;
		//	将 l1 添加到编辑器窗口上
		AddSubview (l1);

		//	初始化标签 l2 - 文本内容为 "屠龙刀", 手动布局
		l2 = new HBLabel (new Rect (80, 120, 160, 32), "倚天剑");
		//	设置字体颜色 - 蓝色
		l2.FontColor = Color.blue;
		//	设置对齐方式 - 水平居中并且垂直居中
		l2.Alignment = TextAnchor.MiddleCenter;
		//	设置字体大小 - 22
		l2.FontSize = 22;
		//	将 l2 添加到编辑器窗口上
		AddSubview (l2);
	}

	private HBLabel l1;	//	标签控件 1
	private HBLabel l2;	//	标签控件 2
}
