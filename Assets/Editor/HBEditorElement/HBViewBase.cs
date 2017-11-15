
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

namespace HBEditorElement
{
    /// <summary>
    /// 是 HBView 和 HBWindow 的基类, 
    /// 主要实现 View 的层级管理和 OnGUI 事件链
    /// </summary>
    public class HBViewBase
    {

        /// <summary>
        /// 是否使用自动布局, 自动布局下不需要设置视图的 Frame
        /// </summary>
        public bool AutoLayout
        {
            get { return _AutoLayout; }
            set { _AutoLayout = value; }
        }

        /// <summary>
        /// 视图的边框, 表示位置和宽高
        /// </summary>
        public Rect Frame
        {
            get { return _Frame; }
            set
            {
                _Frame = value;
                AutoLayout = false;
            }
        }

        /// <summary>
        /// 当前视图所在的 Window
        /// 虚属性, 在子类中如有特殊需要可以重写
        /// </summary>
        public virtual EditorWindow Window
        {
            get { return _Window; }
        }

        /// <summary>
        /// 当前视图的父视图
        /// 虚属性, 在子类中如有特殊需要可以重写
        /// </summary>
        public virtual HBViewBase Super
        {
            get { return _Super; }
        }

        /// <summary>
        /// 当前视图中所有的子视图列表
        /// </summary>
        public List<HBViewBase> Subviews
        {
            get
            {
                if (_Subviews == null)
                {
                    _Subviews = new List<HBViewBase>();
                }
                return _Subviews;
            }
        }

        /// <summary>
        /// 向当前视图中添加子视图
        /// 虚方法, 在子类中如有特殊需要可以重写
        /// </summary>
        public virtual void AddSubview(HBViewBase subview)
        {
            subview.RemoveFromSuperView();
            Subviews.Add(subview);
            subview._Super = this;
            subview._Window = _Window;
        }

        /// <summary>
        /// 将当前视图从父视图上移除, 
        /// 虚方法, 在子类中如有特殊需要可以重写
        /// </summary>
        public virtual void RemoveFromSuperView()
        {
            if (_Super != null)
            {
                _Super.Subviews.Remove(this);
            }
            _Super = null;
            _Window = null;
        }

        /// <summary>
        /// 绘制视图, 调用所有子视图的 WillDraw 和 Draw 方法
        /// 虚方法, 在子类中如有特殊需要可以重写
        /// </summary>
        public virtual void DrawView()
        {
            if (_IsFirstDrawFlag)
            {
                WillDraw();
                _IsFirstDrawFlag = false;
            }
            Draw();
            for (int i = 0; i < Subviews.Count; i++)
            {
                Subviews[i].DrawView();
            }
        }

        /// <summary>
        /// 虚方法, 编写新的控件类时记得重新实现. 在即将开始绘制界面之前, 只调用一次, 用于一些初始化操作
        /// </summary>
        protected virtual void WillDraw() { }

        /// <summary>
        /// 虚方法, 编写新的控件类时记得重新实现. 绘制视图, 相当于 OnGUI 方法
        /// </summary>
        protected virtual void Draw() { }

        private EditorWindow _Window;           //	当前视图所在的 Window
        private HBViewBase _Super;              //	当前视图的父视图
        private List<HBViewBase> _Subviews;     //	当前视图中所有的子视图列表
        private bool _AutoLayout = true;        //	是否使用自动布局, 默认使用
        private Rect _Frame;                    //	视图的边框, 表示位置和宽高
        private bool _IsFirstDrawFlag = true;   //	用来标记是否已经执行过 WillDraw 方法
    }
}
