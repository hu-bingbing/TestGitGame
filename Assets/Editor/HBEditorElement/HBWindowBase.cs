
using System;
using UnityEditor;

namespace HBEditorElement
{
    /// <summary>
    /// 继承于 EditorWindow, 实现编辑器扩展中的一些事件回调
    /// 后期如果需要其他回调可以在此进行添加
    /// 此类并不是 HBWindow 的基类, 而是以组合的方式存在于它的内部
    /// </summary>
    public class HBWindowBase : EditorWindow
    {

        public Action draw; //	OnGUI 的回调

        /// <summary>
        /// 在 OnGUI 中执行回调
        /// </summary>
        private void OnGUI()
        {
            if (draw != null)
            {
                draw();
            }
        }
    }
}
