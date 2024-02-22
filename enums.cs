using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class enums
    {
        public enum SystemMetrics
        {
            SM_CXSCREEN = 0,  // 0x00
            SM_CYSCREEN = 1,  // 0x01
            SM_CXVSCROLL = 2,  // 0x02
            SM_CYHSCROLL = 3,  // 0x03
            SM_CYCAPTION = 4,  // 0x04
            SM_CXBORDER = 5,  // 0x05
            SM_CYBORDER = 6,  // 0x06
            SM_CXDLGFRAME = 7,  // 0x07
            SM_CXFIXEDFRAME = 7,  // 0x07
            SM_CYDLGFRAME = 8,  // 0x08
            SM_CYFIXEDFRAME = 8,  // 0x08
            SM_CYVTHUMB = 9,  // 0x09
            SM_CXHTHUMB = 10, // 0x0A
            SM_CXICON = 11, // 0x0B
            SM_CYICON = 12, // 0x0C
            SM_CXCURSOR = 13, // 0x0D
            SM_CYCURSOR = 14, // 0x0E
            SM_CYMENU = 15, // 0x0F
            SM_CXFULLSCREEN = 16, // 0x10
            SM_CYFULLSCREEN = 17, // 0x11
            SM_CYKANJIWINDOW = 18, // 0x12
            SM_MOUSEPRESENT = 19, // 0x13
            SM_CYVSCROLL = 20, // 0x14
            SM_CXHSCROLL = 21, // 0x15
            SM_DEBUG = 22, // 0x16
            SM_SWAPBUTTON = 23, // 0x17
            SM_CXMIN = 28, // 0x1C
            SM_CYMIN = 29, // 0x1D
            SM_CXSIZE = 30, // 0x1E
            SM_CYSIZE = 31, // 0x1F
            SM_CXSIZEFRAME = 32, // 0x20
            SM_CXFRAME = 32, // 0x20
            SM_CYSIZEFRAME = 33, // 0x21
            SM_CYFRAME = 33, // 0x21
            SM_CXMINTRACK = 34, // 0x22
            SM_CYMINTRACK = 35, // 0x23
            SM_CXDOUBLECLK = 36, // 0x24
            SM_CYDOUBLECLK = 37, // 0x25
            SM_CXICONSPACING = 38, // 0x26
            SM_CYICONSPACING = 39, // 0x27
            SM_MENUDROPALIGNMENT = 40, // 0x28
            SM_PENWINDOWS = 41, // 0x29
            SM_DBCSENABLED = 42, // 0x2A
            SM_CMOUSEBUTTONS = 43, // 0x2B
            SM_SECURE = 44, // 0x2C
            SM_CXEDGE = 45, // 0x2D
            SM_CYEDGE = 46, // 0x2E
            SM_CXMINSPACING = 47, // 0x2F
            SM_CYMINSPACING = 48, // 0x30
            SM_CXSMICON = 49, // 0x31
            SM_CYSMICON = 50, // 0x32
            SM_CYSMCAPTION = 51, // 0x33
            SM_CXSMSIZE = 52, // 0x34
            SM_CYSMSIZE = 53, // 0x35
            SM_CXMENUSIZE = 54, // 0x36
            SM_CYMENUSIZE = 55, // 0x37
            SM_ARRANGE = 56, // 0x38
            SM_CXMINIMIZED = 57, // 0x39
            SM_CYMINIMIZED = 58, // 0x3A
            SM_CXMAXTRACK = 59, // 0x3B
            SM_CYMAXTRACK = 60, // 0x3C
            SM_CXMAXIMIZED = 61, // 0x3D
            SM_CYMAXIMIZED = 62, // 0x3E
            SM_NETWORK = 63, // 0x3F
            SM_CLEANBOOT = 67, // 0x43
            SM_CXDRAG = 68, // 0x44
            SM_CYDRAG = 69, // 0x45
            SM_SHOWSOUNDS = 70, // 0x46
            SM_CXMENUCHECK = 71, // 0x47
            SM_CYMENUCHECK = 72, // 0x48
            SM_SLOWMACHINE = 73, // 0x49
            SM_MIDEASTENABLED = 74, // 0x4A
            SM_MOUSEWHEELPRESENT = 75, // 0x4B
            SM_XVIRTUALSCREEN = 76, // 0x4C
            SM_YVIRTUALSCREEN = 77, // 0x4D
            SM_CXVIRTUALSCREEN = 78, // 0x4E
            SM_CYVIRTUALSCREEN = 79, // 0x4F
            SM_CMONITORS = 80, // 0x50
            SM_SAMEDISPLAYFORMAT = 81, // 0x51
            SM_IMMENABLED = 82, // 0x52
            SM_CXFOCUSBORDER = 83, // 0x53
            SM_CYFOCUSBORDER = 84, // 0x54
            SM_TABLETPC = 86, // 0x56
            SM_MEDIACENTER = 87, // 0x57
            SM_STARTER = 88, // 0x58
            SM_SERVERR2 = 89, // 0x59
            SM_MOUSEHORIZONTALWHEELPRESENT = 91, // 0x5B
            SM_CXPADDEDBORDER = 92, // 0x5C
            SM_DIGITIZER = 94, // 0x5E
            SM_MAXIMUMTOUCHES = 95, // 0x5F
            SM_REMOTESESSION = 0x1000, // 0x1000
            SM_SHUTTINGDOWN = 0x2000, // 0x2000
            SM_REMOTECONTROL = 0x2001, // 0x2001
            SM_CONVERTIBLESLATEMODE = 0x2003,
            SM_SYSTEMDOCKED = 0x2004,
        }
        public enum SystemElementsToColor
        {
            COLOR_3DDKSHADOW = 21,//Dark shadow for three-dimensional display elements.
              COLOR_3DLIGHT = 22,//Light color for three-dimensional display elements(for edges facing the light source.)
             COLOR_ACTIVEBORDER = 10,//Active window border.
            COLOR_ACTIVECAPTION = 2,//Active window title bar. The associated foreground color is COLOR_CAPTIONTEXT.
                                   //Specifies the left side color in the color gradient of an active window's title bar if the gradient effect is enabled.
            COLOR_APPWORKSPACE = 12,//Background color of multiple document interface (MDI) applications.
            COLOR_BTNFACE = 15,//Face color for three-dimensional display elements and for dialog box backgrounds.The associated foreground color is COLOR_BTNTEXT.
             COLOR_BTNHILIGHT = 20,//Highlight color for three-dimensional display elements(for edges facing the light source.)
            COLOR_BTNSHADOW = 16,//Shadow color for three-dimensional display elements(for edges facing away from the light source).
            COLOR_BTNTEXT = 18,//Text on push buttons.The associated background color is COLOR_BTNFACE.
            COLOR_CAPTIONTEXT = 9,//Text in caption, size box, and scroll bar arrow box.The associated background color is COLOR_ACTIVECAPTION.
            COLOR_DESKTOP = 1,//Desktop.
            COLOR_GRADIENTACTIVECAPTION = 27,//Right side color in the color gradient of an active window's title bar. COLOR_ACTIVECAPTION specifies the left side color. Use SPI_GETGRADIENTCAPTIONS with the SystemParametersInfo function to determine whether the gradient effect is enabled.
            COLOR_GRADIENTINACTIVECAPTION = 28,//Right side color in the color gradient of an inactive window's title bar. COLOR_INACTIVECAPTION specifies the left side color.
            COLOR_GRAYTEXT = 17,//Grayed (disabled) text. This color is set to 0 if the current display driver does not support a solid gray color.
            COLOR_HIGHLIGHT = 13,//Item(s) selected in a control. The associated foreground color is COLOR_HIGHLIGHTTEXT.
            COLOR_HIGHLIGHTTEXT = 14,//Text of item(s) selected in a control. The associated background color is COLOR_HIGHLIGHT.
            COLOR_HOTLIGHT = 26,//Color for a hyperlink or hot-tracked item. The associated background color is COLOR_WINDOW.
            COLOR_INACTIVEBORDER = 11,//Inactive window border.
            COLOR_INACTIVECAPTION = 3,//Inactive window caption.
                                      //The associated foreground color is COLOR_INACTIVECAPTIONTEXT.
                                      //Specifies the left side color in the color gradient of an inactive window's title bar if the gradient effect is enabled.
            COLOR_INACTIVECAPTIONTEXT = 19,//Color of text in an inactive caption.The associated background color is COLOR_INACTIVECAPTION.
            COLOR_INFOBK = 24,//Background color for tooltip controls. The associated foreground color is COLOR_INFOTEXT.
            COLOR_INFOTEXT = 23,//Text color for tooltip controls. The associated background color is COLOR_INFOBK.
            COLOR_MENU = 4,//Menu background. The associated foreground color is COLOR_MENUTEXT.
            COLOR_MENUHILIGHT = 29,//The color used to highlight menu items when the menu appears as a flat menu (see SystemParametersInfo). The highlighted menu item is outlined with COLOR_HIGHLIGHT.
                                   //Windows 2000:  This value is not supported.
            COLOR_MENUBAR = 30,//The background color for the menu bar when menus appear as flat menus (see SystemParametersInfo). However, COLOR_MENU continues to specify the background color of the menu popup.
                               //Windows 2000:  This value is not supported.
            COLOR_MENUTEXT = 7,//Text in menus.The associated background color is COLOR_MENU.
            COLOR_SCROLLBAR = 0,//Scroll bar gray area.
            COLOR_WINDOW = 5,//Window background. The associated foreground colors are COLOR_WINDOWTEXT and COLOR_HOTLITE.
            COLOR_WINDOWFRAME = 6,//Window frame.
            COLOR_WINDOWTEXT = 8//Text in windows.The associated background color
        }
        public enum ColorFromRGB : int
        {
            Maroon = 0x800000,
            DarkRed = 0x8B0000,
            Brown = 0xA52A2A,
            Firebrick = 0xB22222,
            Crimson = 0xDC143C,
            Red = 0xFF0000,
            Tomato = 0xFF6347,
            Coral = 0xFF7F50,
            IndianRed = 0xCD5C5C,
            LightCoral = 0xF08080,
            DarkSalmon = 0xE9967A,
            Salmon = 0xFA8072,
            LightSalmon = 0xFFA07A,
            OrangeRed = 0xFF4500,
            DarkOrange = 0xFF8C00,
            Orange = 0xFFA500,
            Gold = 0xFFD700,
            DarkGoldenRod = 0xB8860B,
            GoldenRod = 0xDAA520,
            PaleGoldenRod = 0xEEE8AA,
            DarkKhaki = 0xBDB76B,
            Khaki = 0xF0E68C,
            Olive = 0x808000,
            Yellow = 0xFFFF00,
            YellowGreen = 0x9ACD32,
            DarkOliveGreen = 0x556B2F,
            OliveDrab = 0x6B8E23,
            LawnGreen = 0x7CFC00,
            ChartReuse = 0x7FFF00,
            GreenYellow = 0xADFF2F,
            DarkGreen = 0x006400,
            Green = 0x008000,
            ForestGreen = 0x228B22,
            Lime = 0x00FF00,
            LimeGreen = 0x32CD32,
            LightGreen = 0x90EE90,
            PaleGreen = 0x98FB98,
            DarkSeaGreen = 0x8FBC8F,
            MediumSpringGreen = 0x00FA9A,
            SpringGreen = 0x00FF7F,
            SeaGreen = 0x2E8B57,
            MediumAquaMarine = 0x66CDAA,
            MediumSeaGreen = 0x3CB371,
            LightSeaGreen = 0x20B2AA,
            DarkSlateGray = 0x2F4F4F,
            Teal = 0x008080,
            DarkCyan = 0x008B8B,
            Aqua = 0x00FFFF,
            Cyan = 0x00FFFF,
            LightCyan = 0xE0FFFF,
            DarkTurquoise = 0x00CED1,
            Turquoise = 0x40E0D0,
            MediumTurquoise = 0x48D1CC,
            PaleTurquoise = 0xAFEEEE,
            AquaMarine = 0x7FFFD4,
            PowderBlue = 0xB0E0E6,
            CadetBlue = 0x5F9EA0,
            SteelBlue = 0x4682B4,
            CornFlowerBlue = 0x6495ED,
            DeepSkyBlue = 0x00BFFF,
            DodgerBlue = 0x1E90FF,
            LightBlue = 0xADD8E6,
            SkyBlue = 0x87CEEB,
            LightSkyBlue = 0x87CEFA,
            MidnightBlue = 0x191970,
            Navy = 0x000080,
            DarkBlue = 0x00008B,
            MediumBlue = 0x0000CD,
            Blue = 0x0000FF,
            RoyalBlue = 0x4169E1,
            BlueViolet = 0x8A2BE2,
            Indigo = 0x4B0082,
            DarkSlateBlue = 0x483D8B,
            SlateBlue = 0x6A5ACD,
            MediumSlateBlue = 0x7B68EE,
            MediumPurple = 0x9370DB,
            DarkMagenta = 0x8B008B,
            DarkViolet = 0x9400D3,
            DarkOrchid = 0x9932CC,
            MediumOrchid = 0xBA55D3,
            Purple = 0x800080,
            Thistle = 0xD8BFD8,
            Plum = 0xDDA0DD,
            Violet = 0xEE82EE,
            MagentaFuchsia = 0xFF00FF,
            Orchid = 0xDA70D6,
            MediumVioletRed = 0xC71585,
            PaleVioletRed = 0xDB7093,
            DeepPink = 0xFF1493,
            HotPink = 0xFF69B4,
            LightPink = 0xFFB6C1,
            Pink = 0xFFC0CB,
        }
    }
}
