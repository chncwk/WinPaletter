﻿using System;
using System.Runtime.InteropServices;

namespace WinPaletter.NativeMethods
{
    /// <summary>
    /// Provides P/Invoke declarations for the Desktop Window Manager (DWM) API.
    /// </summary>
    public class DWMAPI
    {
        #region Constants
        /// <summary>
        /// Represents a constant value for enabling drop shadow in a window.
        /// </summary>
        public const int CS_DROPSHADOW = 0x20000;

        /// <summary>
        /// Represents a constant value for the WM_NCPAINT message.
        /// </summary>
        public const int WM_NCPAINT = 0x85;

        /// <summary>
        /// Represents a constant value for enabling blur in a region for DWM.
        /// </summary>
        public const int DWM_BB_BLURREGION = 2;

        /// <summary>
        /// Represents a constant value for enabling DWM composition.
        /// </summary>
        public const int DWM_BB_ENABLE = 1;

        /// <summary>
        /// Represents a constant value for transitioning on maximized state for DWM.
        /// </summary>
        public const int DWM_BB_TRANSITIONONMAXIMIZED = 4;

        /// <summary>
        /// Represents the base name for DWM composed events.
        /// </summary>
        public const string DWM_COMPOSED_EVENT_BASE_NAME = "DwmComposedEvent_";

        /// <summary>
        /// Represents the format for the name of DWM composed events.
        /// </summary>
        public const string DWM_COMPOSED_EVENT_NAME_FORMAT = "%s%d";

        /// <summary>
        /// Represents the maximum length of the name for DWM composed events.
        /// </summary>
        public const int DWM_COMPOSED_EVENT_NAME_MAX_LENGTH = 0x40;

        /// <summary>
        /// Represents the default duration for a DWM frame.
        /// </summary>
        public const int DWM_FRAME_DURATION_DEFAULT = -1;

        /// <summary>
        /// Represents a constant value for DWM transparency.
        /// </summary>
        public const int DWM_TNP_OPACITY = 4;

        /// <summary>
        /// Represents a constant value for DWM destination rectangle.
        /// </summary>
        public const int DWM_TNP_RECTDESTINATION = 1;

        /// <summary>
        /// Represents a constant value for DWM source rectangle.
        /// </summary>
        public const int DWM_TNP_RECTSOURCE = 2;

        /// <summary>
        /// Represents a constant value for limiting the source to the client area only in DWM.
        /// </summary>
        public const int DWM_TNP_SOURCECLIENTAREAONLY = 0x10;

        /// <summary>
        /// Represents a constant value for DWM visibility.
        /// </summary>
        public const int DWM_TNP_VISIBLE = 8;

        /// <summary>
        /// Represents a constant value for the WM_DWMCOMPOSITIONCHANGED message.
        /// </summary>
        public const int WM_DWMCOMPOSITIONCHANGED = 0x31e;
        #endregion

        #region Methods
        /// <summary>
        /// Enables or disables the blur effect behind a window.
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="pBlurBehind">A pointer to a DWM_BLURBEHIND structure that describes the blur-behind area.</param>
        [DllImport("dwmapi.dll", PreserveSig = false)]
        public static extern void DwmEnableBlurBehindWindow(IntPtr hWnd, DWM_BLURBEHIND pBlurBehind);

        /// <summary>
        /// Queries the composition state of Desktop Window Manager (DWM).
        /// </summary>
        /// <param name="isEnabled">Receives the current composition state. True if composition is enabled; otherwise, false.</param>
        /// <returns>Returns S_OK if successful; otherwise, an HRESULT error code.</returns>
        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(out bool isEnabled);

        /// <summary>
        /// Enables or disables Desktop Window Manager (DWM) composition.
        /// </summary>
        /// <param name="bEnable">True to enable composition; false to disable composition.</param>
        [DllImport("dwmapi.dll", PreserveSig = false)]
        public static extern void DwmEnableComposition(bool bEnable);

        /// <summary>
        /// Enables or disables Desktop Window Manager (DWM) composition.
        /// </summary>
        /// <param name="fEnable">1 to enable composition; 0 to disable composition.</param>
        [DllImport("dwmapi.dll")]
        public static extern int DwmEnableComposition(int fEnable);

        /// <summary>
        /// Retrieves the color used for Desktop Window Manager (DWM) glass composition.
        /// </summary>
        /// <param name="pcrColorization">Receives the color value.</param>
        /// <param name="pfOpaqueBlend">Receives whether the color is opaque.</param>
        [DllImport("dwmapi.dll", PreserveSig = false)]
        public static extern void DwmGetColorizationColor(out int pcrColorization, [MarshalAs(UnmanagedType.Bool)] out bool pfOpaqueBlend);

        /// <summary>
        /// Retrieves the color used for Desktop Window Manager (DWM) glass composition.
        /// </summary>
        /// <param name="pcrColorization">Receives the color value.</param>
        /// <param name="pfOpaqueBlend">Receives whether the color is opaque.</param>
        /// <returns>Returns S_OK if successful; otherwise, an HRESULT error code.</returns>
        [DllImport("dwmapi.dll")]
        public static extern int DwmGetColorizationColor(ref int pcrColorization, ref int pfOpaqueBlend);

        /// <summary>
        /// Extends the window frame into the client area.
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="pMarInset">A pointer to a MARGINS structure that describes the margins to use when extending the frame into the client area.</param>
        /// <returns>Returns S_OK if successful; otherwise, an HRESULT error code.</returns>
        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        /// <summary>
        /// Sets the value of Desktop Window Manager (DWM) non-client rendering attributes.
        /// </summary>
        /// <param name="hwnd">A handle to the window.</param>
        /// <param name="attr">The attribute to set.</param>
        /// <param name="attrValue">The value to set.</param>
        /// <param name="attrSize">The size of the value being set.</param>
        /// <returns>Returns S_OK if successful; otherwise, an HRESULT error code.</returns>
        [DllImport("dwmapi.dll")]
        internal static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        /// <summary>
        /// Sets the value of Desktop Window Manager (DWM) non-client rendering attributes.
        /// </summary>
        /// <param name="hwnd">A handle to the window.</param>
        /// <param name="dwAttribute">The attribute to set.</param>
        /// <param name="pvAttribute">The value to set.</param>
        /// <param name="cbAttribute">The size, in bytes, of the pvAttribute value.</param>
        /// <returns>Returns S_OK if successful; otherwise, an HRESULT error code.</returns>
        [DllImport("dwmapi.dll")]
        internal static extern int DwmSetWindowAttribute(IntPtr hwnd, DWMATTRIB dwAttribute, ref int pvAttribute, int cbAttribute);

        /// <summary>
        /// Sets the Desktop Window Manager (DWM) colorization parameters.
        /// </summary>
        /// <param name="parameters">A pointer to a DWM_COLORIZATION_PARAMS structure that specifies the colorization parameters.</param>
        /// <param name="unknown">Unknown parameter.</param>
        /// <returns>Returns S_OK if successful; otherwise, an HRESULT error code.</returns>
        [DllImport("dwmapi.dll", EntryPoint = "#131", PreserveSig = false)]
        public static extern void DwmSetColorizationParameters(ref DWM_COLORIZATION_PARAMS parameters, bool unknown);

        /// <summary>
        /// Retrieves the value of Desktop Window Manager (DWM) non-client rendering attributes for a window.
        /// </summary>
        /// <param name="hwnd">A handle to the window.</param>
        /// <param name="dwAttribute">The attribute to retrieve.</param>
        /// <param name="pvAttribute">A pointer to a value that, when this function returns successfully, receives the value of the attribute.</param>
        /// <param name="cbAttribute">The size, in bytes, of the pvAttribute value.</param>
        /// <returns>Returns S_OK if successful; otherwise, an HRESULT error code.</returns>
        [DllImport("dwmapi.dll")]
        public static extern int DwmGetWindowAttribute(IntPtr hwnd, int dwAttribute, IntPtr pvAttribute, int cbAttribute);

        /// <summary>
        /// Sets the present parameters for Desktop Window Manager (DWM).
        /// </summary>
        /// <param name="hwnd">A handle to the window.</param>
        /// <param name="pPresentParams">A pointer to a DWM_PRESENT_PARAMETERS structure that contains the present parameters to set.</param>
        /// <returns>Returns S_OK if successful; otherwise, an HRESULT error code.</returns>
        [DllImport("dwmapi.dll")]
        public static extern int DwmSetPresentParameters(IntPtr hwnd, ref DWM_PRESENT_PARAMETERS pPresentParams);

        /// <summary>
        /// Sets the value of Desktop Window Manager (DWM) non-client rendering attributes for a window.
        /// </summary>
        /// <param name="hwnd">A handle to the window.</param>
        /// <param name="dwAttribute">The attribute to set.</param>
        /// <param name="pvAttribute">A pointer to a value that contains the attribute value.</param>
        /// <param name="cbAttribute">The size, in bytes, of the pvAttribute value.</param>
        /// <returns>Returns S_OK if successful; otherwise, an HRESULT error code.</returns>
        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int dwAttribute, IntPtr pvAttribute, int cbAttribute);

        /// <summary>
        /// Checks if Desktop Window Manager (DWM) composition is enabled on the system.
        /// </summary>
        /// <returns>True if DWM composition is enabled; otherwise, false.</returns>
        public static bool IsCompositionEnabled()
        {
            try
            {
                DwmIsCompositionEnabled(out bool isEnabled);
                return Environment.OSVersion.Version.Major >= 6 && isEnabled;
            }
            catch { return false; }
        }
        #endregion

        #region Structures
        /// <summary>
        /// Struct that specifies Desktop Window Manager (DWM) blur behind settings.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct DWM_BLURBEHIND
        {
            /// <summary>
            /// Flags that indicate which members of this structure are valid.
            /// </summary>
            public uint dwFlags;

            /// <summary>
            /// True to enable the blur effect; false to disable.
            /// </summary>
            public bool fEnable;

            /// <summary>
            /// Handle to the region where the blur should be applied.
            /// </summary>
            public IntPtr hRgnBlur;

            /// <summary>
            /// True to transition to a blurred representation when maximized; false otherwise.
            /// </summary>
            public bool fTransitionOnMaximized;

            /// <summary>
            /// Initializes a new instance of the DWM_BLURBEHIND structure.
            /// </summary>
            /// <param name="enable">True to enable the blur effect; false to disable.</param>
            public DWM_BLURBEHIND(bool enable)
            {
                dwFlags = 0x00000003; // DWM_BB_ENABLE | DWM_BB_BLURREGION
                fEnable = enable;
                hRgnBlur = IntPtr.Zero;
                fTransitionOnMaximized = false;
            }
        }

        /// <summary>
        /// Struct that specifies margins for extending the window frame into the client area.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct MARGINS
        {
            /// <summary>
            /// Width of the left border.
            /// </summary>
            public int leftWidth;

            /// <summary>
            /// Width of the right border.
            /// </summary>
            public int rightWidth;

            /// <summary>
            /// Height of the top border.
            /// </summary>
            public int topHeight;

            /// <summary>
            /// Height of the bottom border.
            /// </summary>
            public int bottomHeight;
        }

        /// <summary>
        /// Struct that specifies an unsigned ratio.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct UNSIGNED_RATIO
        {
            /// <summary>
            /// Numerator of the ratio.
            /// </summary>
            public int uiNumerator;

            /// <summary>
            /// Denominator of the ratio.
            /// </summary>
            public int uiDenominator;
        }

        /// <summary>
        /// Struct that specifies a rectangle by the coordinates of its upper-left and lower-right corners.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            /// <summary>
            /// The x-coordinate of the upper-left corner of the rectangle.
            /// </summary>
            public int left;

            /// <summary>
            /// The y-coordinate of the upper-left corner of the rectangle.
            /// </summary>
            public int top;

            /// <summary>
            /// The x-coordinate of the lower-right corner of the rectangle.
            /// </summary>
            public int right;

            /// <summary>
            /// The y-coordinate of the lower-right corner of the rectangle.
            /// </summary>
            public int bottom;

            /// <summary>
            /// Initializes a new instance of the RECT structure with specified coordinates.
            /// </summary>
            /// <param name="left">The x-coordinate of the upper-left corner.</param>
            /// <param name="top">The y-coordinate of the upper-left corner.</param>
            /// <param name="right">The x-coordinate of the lower-right corner.</param>
            /// <param name="bottom">The y-coordinate of the lower-right corner.</param>
            public RECT(int left, int top, int right, int bottom)
            {
                this.left = left; this.top = top;
                this.right = right; this.bottom = bottom;
            }
        }

        /// <summary>
        /// Struct that specifies Desktop Window Manager (DWM) colorization parameters.
        /// </summary>
        public struct DWM_COLORIZATION_PARAMS
        {
            /// <summary>
            /// The color used for colorization.
            /// </summary>
            public uint clrColor;

            /// <summary>
            /// The color of the glow effect that follows colorization.
            /// </summary>
            public uint clrAfterGlow;

            /// <summary>
            /// The intensity of the colorization.
            /// </summary>
            public uint nIntensity;

            /// <summary>
            /// The balance of the colorization after the glow effect is applied.
            /// </summary>
            public uint clrAfterGlowBalance;

            /// <summary>
            /// The balance of the blur effect.
            /// </summary>
            public uint clrBlurBalance;

            /// <summary>
            /// The intensity of the glass reflection effect.
            /// </summary>
            public uint clrGlassReflectionIntensity;

            /// <summary>
            /// True if the colorization is opaque; false if it's not opaque.
            /// </summary>
            public bool fOpaque;
        }

        /// <summary>
        /// Struct that specifies Desktop Window Manager (DWM) present parameters.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct DWM_PRESENT_PARAMETERS
        {
            /// <summary>
            /// The size of this structure.
            /// </summary>
            public int cbSize;

            /// <summary>
            /// The frame to queue, if any.
            /// </summary>
            public int fQueue;

            /// <summary>
            /// The refresh start time, in 100-nanosecond units.
            /// </summary>
            public long cRefreshStart;

            /// <summary>
            /// The number of buffers in the flip chain.
            /// </summary>
            public int cBuffer;

            /// <summary>
            /// True if the source rate should be used; false otherwise.
            /// </summary>
            public int fUseSourceRate;

            /// <summary>
            /// The source rate.
            /// </summary>
            public UNSIGNED_RATIO rateSource;

            /// <summary>
            /// The number of refreshes per frame.
            /// </summary>
            public int cRefreshesPerFrame;

            /// <summary>
            /// The sampling type for the source frame.
            /// </summary>
            public DWM_SOURCE_FRAME_SAMPLING eSampling;
        }

        #endregion

        #region Enumerations
        /// <summary>
        /// Enumerates Desktop Window Manager (DWM) attributes.
        /// </summary>
        public enum DWMATTRIB : int
        {
            /// <summary>
            /// Specifies the type of the system backdrop.
            /// </summary>
            SYSTEMBACKDROP_TYPE = 38,

            /// <summary>
            /// Specifies the Mica effect attribute.
            /// </summary>
            MICA_EFFECT = 1029,

            /// <summary>
            /// Specifies the attribute for using immersive dark mode.
            /// </summary>
            USE_IMMERSIVE_DARK_MODE = 20,

            /// <summary>
            /// Specifies the window corner preference attribute.
            /// </summary>
            WINDOW_CORNER_PREFERENCE = 33,

            /// <summary>
            /// Specifies the text color attribute.
            /// </summary>
            TEXT_COLOR = 36,

            /// <summary>
            /// Specifies the caption color attribute.
            /// </summary>
            CAPTION_COLOR = 35,

            /// <summary>
            /// Specifies the border color attribute.
            /// </summary>
            BORDER_COLOR = 34
        }

        /// <summary>
        /// Enumerates different types of form corners.
        /// </summary>
        public enum FormCornersType
        {
            /// <summary>
            /// Default form corners.
            /// </summary>
            Default,

            /// <summary>
            /// Rectangular form corners.
            /// </summary>
            Rectangular,

            /// <summary>
            /// Round form corners.
            /// </summary>
            Round,

            /// <summary>
            /// Small round form corners.
            /// </summary>
            SmallRound
        }

        /// <summary>
        /// Enumerates Desktop Window Manager (DWM) source frame sampling types.
        /// </summary>
        public enum DWM_SOURCE_FRAME_SAMPLING
        {
            /// <summary>
            /// Specifies point sampling for source frames.
            /// </summary>
            DWM_SOURCE_FRAME_SAMPLING_POINT,

            /// <summary>
            /// Specifies coverage sampling for source frames.
            /// </summary>
            DWM_SOURCE_FRAME_SAMPLING_COVERAGE,

            /// <summary>
            /// Specifies the last available source frame sampling type.
            /// </summary>
            DWM_SOURCE_FRAME_SAMPLING_LAST
        }

        #endregion
    }
}
