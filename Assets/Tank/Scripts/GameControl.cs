
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

	public InputField inputField;

	//	点击保存按钮之后
	public void DidClickSaveButton () {
		//	如果用户输入了地图名字
		if (inputField.text != null && inputField.text != "") {
			//	获取地图名字
			string key = inputField.text;
			//	获取 Map 游戏对象
			GameObject map = GameObject.FindGameObjectWithTag ("Map");
			//	获取 Map 脚本组件
			Map m = map.GetComponent <Map> ();
			//	获取当前地图中的数据模型数组
			BlockModel [,] value = m.models;
			//	获取保存地图的单例
			MapList ml = MapList.GetInstnce ();
			//	将地图数据模型存入单例的成员变量中
			ml.maps.Add (key, value);
		}
	}

	//	点击了返回主菜单按钮
	public void DidClickBackButton () {
		//	加载主菜单场景
        SceneManager.LoadScene(0);
	}

	//	点击了打开编辑器按钮
	public void DidClickOpenEditButton () {
		//	如果制定了某张地图则打开进行编辑
		if (inputField.text != "") {
			//	保存用户希望打开的地图
			MapList.GetInstnce ().loadMapName = inputField.text;
		} else {
			MapList.GetInstnce ().loadMapName = "";
		}
        //	加载编辑器场景
        SceneManager.LoadScene("EditScene");
	}
}
