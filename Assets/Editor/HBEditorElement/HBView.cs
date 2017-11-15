
using UnityEditor;
using UnityEngine;

namespace HBEditorElement
{
    /// <summary>
    /// 所有可视化控件的基类, 用来定义控件共同的属性
    /// </summary>
    public class HBView : HBViewBase
    {

        /// <summary>
        /// GUI 的样式
        /// </summary>
        public GUIStyle Style
        {
            get { return _Style; }
            set { _Style = value; }
        }

        private GUIStyle _Style;    //	GUI 的样式
    }
}
