using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Basic.Framework.Pinvoke
{
    /// <summary>
    /// AnimateWindowFlags
    /// </summary>
    public enum AnimateWindowFlags
    {
        /// <summary>
        /// 自左向右显示窗口。该标志可以在滚动动画和滑动动画中使用。
        /// </summary>
        AW_HOR_POSITIVE = 0x00000001,
        /// <summary>
        /// 自右向左显示窗口。该标志可以在滚动动画和滑动动画中使用
        /// </summary>
        AW_HOR_NEGATIVE = 0x00000002,
        /// <summary>
        /// 自顶向下显示窗口。该标志可以在滚动动画和滑动动画中使用。
        /// </summary>
        AW_VER_POSITIVE = 0x00000004,
        /// <summary>
        /// 自下向上显示窗口。该标志可以在滚动动画和滑动动画中使用。
        /// </summary>
        AW_VER_NEGATIVE = 0x00000008,
        /// <summary>
        /// 若使用了AW_HIDE标志，则使窗口向内重叠；若未使用AW_HIDE标志，则使窗口向外扩展。
        /// </summary>
        AW_CENTER = 0x00000010,
        /// <summary>
        /// 隐藏窗体
        /// </summary>
        AW_HIDE = 0x00010000,
        /// <summary>
        ///  激活窗体
        /// </summary>
        AW_ACTIVATE = 0x00020000,
        /// <summary>
        /// 使用滑动类型。缺省则为滚动动画类型。
        /// </summary>
        AW_SLIDE = 0x00040000,
        /// <summary>
        /// 使用淡出效果。只有当hWnd为顶层窗口的时候才可以使用此标志。
        /// </summary>
        AW_BLEND = 0x00080000,
        /// <summary>
        ///  左上到右下效果。
        /// </summary>
        AW_LEFTTOP_RIGHTBOTTOM = 0x00000005,
        /// <summary>
        /// 右上到左下效果。
        /// </summary>
        AW_RIGHTTOP_LEFTTOTTOM = 0x00000006,
        /// <summary>
        ///  左下到右上效果。
        /// </summary>
        AW_LEFTTOTTOM_RIGHTTOP = 0x00000009,

    }
}

