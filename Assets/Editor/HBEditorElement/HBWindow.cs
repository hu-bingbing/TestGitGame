
using UnityEditor;
using UnityEngine;

namespace HBEditorElement
{
    /// <summary>
    /// 编辑器窗口类, 
    /// 继承于 HBViewBase, 
    /// 并且类内部包含一个 HBWindowBase 实例, 用于设置编辑器事件回调
    /// </summary>
    public class HBWindow : HBViewBase
    {

        /// <summary>
        /// 当前视图所在的 Window
        /// 虚属性, 在子类中如有特殊需要可以重写
        /// </summary>
        public override EditorWindow Window
        {
            get { return _Window; }
        }

        /// <summary>
        /// 当前视图的父视图
        /// 虚属性, 在子类中如有特殊需要可以重写
        /// </summary>
        public override HBViewBase Super
        {
            get { return this; }
        }

        /// <summary>
        /// 将当前视图从父视图上移除, 对于 Window 来说就是直接关闭窗口
        /// 虚方法, 在子类中如有特殊需要可以重写
        /// </summary>
        public override void RemoveFromSuperView()
        {
            _Window.Close();
        }

        /// <summary>
        /// 显示窗口
        /// </summary>
        /// <param name="frame"> 窗口的位置和大小 </param>
        /// <param name="title"> 窗口标题 </param>
        /// <param name="utility"> 如果值为 <c>true</c> 则窗口不能吸附在编辑器中 </param>
        public void Show(Rect frame, string title, bool utility = false)
        {
            Frame = frame;
            AutoLayout = false;
            InitWindow(title, utility);
        }

        /// <summary>
        /// 显示窗口
        /// </summary>
        /// <param name="title"> 窗口标题 </param>
        /// <param name="utility"> 如果值为 <c>true</c> 则窗口不能吸附在编辑器中 </param>
        public void Show(string title, bool utility = false)
        {
            InitWindow(title, utility);
        }

        /// <summary>
        /// 布局子视图
        /// 虚方法, 需要在子类中重写
        /// </summary>
        protected virtual void LayoutSubviews() { }

        private EditorWindow _Window;   //	编辑器窗口

        /// <summary>
        /// 初始化 Window
        /// </summary>
        private void InitWindow(string title, bool utility)
        {
            if (AutoLayout)
            {
                _Window = EditorWindow.GetWindow<HBWindowBase>(utility, title, true);
            }
            else
            {
                _Window = EditorWindow.GetWindowWithRect<HBWindowBase>(Frame, utility, title, true);
            }
            _Window.Show();
            (_Window as HBWindowBase).draw = DrawView;
            LayoutSubviews();
        }
    }
}
