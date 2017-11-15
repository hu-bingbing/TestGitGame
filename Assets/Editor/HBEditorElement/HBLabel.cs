
using UnityEditor;
using UnityEngine;

namespace HBEditorElement
{
    /// <summary>
    /// 标签, 用于显示文本信息
    /// </summary>
    public class HBLabel : HBView
    {

        /// <summary>
        /// 标签标题
        /// </summary>
        public string title;

        /// <summary>
        /// 是否使用阴影, 默认不使用
        /// </summary>
        public bool useShadow = false;

        /// <summary>
        /// 阴影偏移量, 默认为 1
        /// </summary>
        public float shadowOffset = 1f;

        /// <summary>
        /// 字体大小
        /// </summary>
        public int FontSize
        {
            get { return _FontSize; }
            set
            {
                _FontSize = value;
                if (Style != null)
                {
                    Style.fontSize = _FontSize;
                }
            }
        }

        /// <summary>
        /// 字体颜色
        /// </summary>
        public Color FontColor
        {
            get { return _FontColor; }
            set
            {
                _FontColor = value;
                if (Style != null)
                {
                    Style.normal.textColor = _FontColor;
                }
            }
        }

        /// <summary>
        /// 字体对齐方式
        /// </summary>
        public TextAnchor Alignment
        {
            get { return _Alignment; }
            set
            {
                _Alignment = value;
                if (Style != null)
                {
                    Style.alignment = _Alignment;
                }
            }
        }

        /// <summary>
        /// 阴影颜色, 默认为灰色
        /// </summary>
        public Color ShadowColor
        {
            get { return _ShadowColor; }
            set
            {
                _ShadowColor = value;
                if (_ShadowStyle != null)
                {
                    _ShadowStyle.normal.textColor = _ShadowColor;
                }
            }
        }

        /// <summary>
        /// 构造方法, 使用自动布局
        /// </summary>
        /// <param name="title"> 标签标题 </param>
        /// <param name="options"> GUI 布局选项 </param>
        public HBLabel(string title, params GUILayoutOption[] options)
        {
            _Options = options;
            Init(title);
        }

        /// <summary>
        /// 构造方法, 不使用自动布局
        /// </summary>
        /// <param name="frame"> 标签的位置和大小 </param>
        /// <param name="title"> 标签标题 </param>
        public HBLabel(Rect frame, string title)
        {
            AutoLayout = false;
            Frame = frame;
            Init(title);
        }

        /// <summary>
        /// 虚方法, 编写新的控件类时记得重新实现. 在即将开始绘制界面之前, 只调用一次, 用于一些初始化操作
        /// </summary>
        protected override void WillDraw()
        {
            Style = new GUIStyle(GUI.skin.label);
            Style.richText = true;
            Style.fontSize = _FontSize;
            Style.normal.textColor = _FontColor;
            Style.alignment = _Alignment;
            _ShadowStyle = new GUIStyle(Style);
            _ShadowStyle.normal.textColor = _ShadowColor;
        }

        /// <summary>
        /// 虚方法, 编写新的控件类时记得重新实现. 绘制视图, 相当于 OnGUI 方法
        /// </summary>
        protected override void Draw()
        {
            if (useShadow)
            {
                if (AutoLayout)
                {
                    GUILayout.Label(title, _ShadowStyle, _Options);
                    _ContentFrame = GUILayoutUtility.GetLastRect();
                }
                else
                {
                    GUI.Label(Frame, title, _ShadowStyle);
                    _ContentFrame = Frame;
                }
                _ContentFrame.x -= shadowOffset;
                _ContentFrame.y -= shadowOffset;
                GUI.Label(_ContentFrame, title, Style);
            }
            else
            {
                if (AutoLayout)
                {
                    GUILayout.Label(title, Style, _Options);
                }
                else
                {
                    GUI.Label(Frame, title, Style);
                }
            }
        }

        private int _FontSize = 16; //	字体大小, 默认 16
        private Color _FontColor = Color.black; //	字体颜色, 默认黑色
        private TextAnchor _Alignment = TextAnchor.UpperLeft;   //	字体对齐方式, 默认左上对齐
        private GUILayoutOption[] _Options; //	GUI 布局选项
        private Color _ShadowColor = Color.gray;    //	阴影颜色, 默认为灰色
        private GUIStyle _ShadowStyle;  //	阴影样式
        private Rect _ContentFrame; //	内容的位置大小

        /// <summary>
        /// 初始化方法
        /// </summary>
        private void Init(string title)
        {
            this.title = title;
        }
    }
}
