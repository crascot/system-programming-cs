using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using static lab1.enums;

namespace lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += clickEvent;
            button2.Click += ShowCursorButton;
            button3.Click += GetKeyboardLayouts;
            button4.Click += GetTickCountButton;
            button5.Click += MessageBeepButton;
            button6.Click += setColor_Btn;
        }
        public void clickEvent(object sender, EventArgs e)
        {
            label1.Text = $"Имя пользователя: {GetUserName()}";
            label2.Text = $"Имя компьютера: {GetComputerName()}";
            label3.Text = $"Пути к системным каталогам Windows: {GetSystemDirectory()}";
            label4.Text = GetOSVersion();
            label5.Text = GetSystemMetrix();
            label6.Text = GetSystemParameters();
            label8.Text = GetCurrentLocalTimeAsString();
            label9.Text = GetTimeZoneInformationAsString();
            label10.Text = GetFormattedTime();
        }

        // Импортируем функцию GetUserName из user32.dll
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool GetUserName(StringBuilder lpBuffer, ref int size);
        private string GetUserName()
        {
            const int maxUsernameLength = 256; // Максимальная длина имени пользователя

            StringBuilder usernameBuffer = new StringBuilder(maxUsernameLength);
            int bufferSize = maxUsernameLength;

            // Получаем имя пользователя
            bool success = GetUserName(usernameBuffer, ref bufferSize);

            if (success)
            {
                return usernameBuffer.ToString();
            }
            else
            {
                return "Не удалось получить имя пользователя";
            }
        }
        //*********************************************************************************

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool GetComputerName(StringBuilder lpBuffer, ref int size);
        private string GetComputerName()
        {
            const int maxComputerNameLength = 256; // Максимальная длина имени компьютера

            StringBuilder computerNameBuffer = new StringBuilder(maxComputerNameLength);
            int bufferSize = maxComputerNameLength;

            // Получаем имя компьютера
            bool success = GetComputerName(computerNameBuffer, ref bufferSize);

            if (success)
            {
                return computerNameBuffer.ToString();
            }
            else
            {
                return "Не удалось получить имя компьютера";
            }
        }
        //**************************************************************************************

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern uint GetSystemDirectory([Out] char[] lpBuffer, uint uSize);
        private string GetSystemDirectory()
        {
            // Определяем размер буфера для хранения пути к системному каталогу
            uint bufferSize = 260; // MAX_PATH

            // Создаем массив символов для хранения пути
            char[] systemPathBuffer = new char[bufferSize];

            // Получаем путь к системному каталогу
            uint result = GetSystemDirectory(systemPathBuffer, bufferSize);

            if (result != 0)
            {
                // Преобразуем массив символов в строку и возвращаем результат
                return new string(systemPathBuffer);
            }
            else
            {
                return null;
            }
        }
        //************************************************************************************************

        [StructLayout(LayoutKind.Sequential)]
        public class OSVersionInfo
        {
            public uint dwOSVersionInfoSize;
            public uint dwMajorVersion;
            public uint dwMinorVersion;
            public uint dwBuildNumber;
            public uint dwPlatformId;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public String szCSDVersion;
        }

        class Kernel
        {
            [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
            public static extern bool GetVersionEx([In, Out] OSVersionInfo info);
        }
        private string GetOSVersion()
        {
            OSVersionInfo version = new OSVersionInfo();
            version.dwOSVersionInfoSize = (uint)Marshal.SizeOf(version);
            Kernel.GetVersionEx(version);
            return $"Версия операционной системы: {version.dwBuildNumber.ToString()}";
        }
        //******************************************************************************************************

        private string GetSystemMetrix()
        {
            ulong usedPhysicalMemory = GetUsedPhysicalMemory();
            ulong freeBytesAvailable;
            ulong totalNumberOfBytes;
            ulong totalNumberOfFreeBytes;

            if (GetDiskFreeSpaceEx("C:\\", out freeBytesAvailable, out totalNumberOfBytes, out totalNumberOfFreeBytes))
            {
                return $"Системные метрики:\n" +
                       $"   CPU загрузка: {CalculateCPULoad()}%\n" +
                       $"   Количество используемой RAM: {usedPhysicalMemory / (1024 * 1024)}MB\n" +
                       $"   Свободное место на диске C: {freeBytesAvailable / (1024 * 1024)}";
            }
            else
            {
                return "";
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        struct FILETIME
        {
            public uint dwLowDateTime;
            public uint dwHighDateTime;
        }
        [DllImport("kernel32.dll")]
        static extern bool GetSystemTimes(out FILETIME lpIdleTime, out FILETIME lpKernelTime, out FILETIME lpUserTime);
        static double CalculateCPULoad()
        {
            FILETIME idleTime, kernelTime, userTime;

            if (!GetSystemTimes(out idleTime, out kernelTime, out userTime))
                throw new System.ComponentModel.Win32Exception();

            ulong idleTime64 = (ulong)idleTime.dwHighDateTime << 32 | idleTime.dwLowDateTime;
            ulong kernelTime64 = (ulong)kernelTime.dwHighDateTime << 32 | kernelTime.dwLowDateTime;
            ulong userTime64 = (ulong)userTime.dwHighDateTime << 32 | userTime.dwLowDateTime;

            ulong totalTime64 = kernelTime64 + userTime64;

            double result = (totalTime64 - idleTime64) * 100.0 / totalTime64;

            return result;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct MEMORYSTATUSEX
        {
            public uint dwLength;
            public uint dwMemoryLoad;
            public ulong ullTotalPhys;
            public ulong ullAvailPhys;
            public ulong ullTotalPageFile;
            public ulong ullAvailPageFile;
            public ulong ullTotalVirtual;
            public ulong ullAvailVirtual;
            public ulong ullAvailExtendedVirtual;
        }

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GlobalMemoryStatusEx(ref MEMORYSTATUSEX lpBuffer);

        public static ulong GetUsedPhysicalMemory()
        {
            MEMORYSTATUSEX memoryStatus = new MEMORYSTATUSEX();
            memoryStatus.dwLength = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX));

            if (GlobalMemoryStatusEx(ref memoryStatus))
            {
                return memoryStatus.ullTotalPhys - memoryStatus.ullAvailPhys;
            }
            else
            {
                throw new InvalidOperationException("Failed to retrieve memory information.");
            }
        }

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool GetDiskFreeSpaceEx(string lpDirectoryName,
        out ulong lpFreeBytesAvailable,
        out ulong lpTotalNumberOfBytes,
        out ulong lpTotalNumberOfFreeBytes);

        private string GetSystemParameters()
        {
            SYSTEM_INFO systemInfo;
            GetSystemInfo(out systemInfo);

            return "Системные параметры: \n" +
                   $"Количество ядер: {systemInfo.numberOfProcessors}\n" +
                   $"Количество потоков процессора: {GetProcessorThreadCount()}\n" +
                   $"Объем оперативной памяти: {GetTotalPhysicalMemoryInGB()} гб";
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEM_INFO
        {
            public ushort processorArchitecture;
            ushort reserved;
            public uint pageSize;
            public IntPtr minimumApplicationAddress;
            public IntPtr maximumApplicationAddress;
            public IntPtr activeProcessorMask;
            public uint numberOfProcessors;
            public uint processorType;
            public uint allocationGranularity;
            public ushort processorLevel;
            public ushort processorRevision;
        }

        [DllImport("kernel32.dll")]
        static extern void GetSystemInfo(out SYSTEM_INFO lpSystemInfo);
        //*************************

        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEM_LOGICAL_PROCESSOR_INFORMATION
        {
            public IntPtr ProcessorMask;
            public int Relationship;
            public ProcessorInfoUnion ProcessorInformation;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct ProcessorInfoUnion
        {
            [FieldOffset(0)]
            public ProcessorCoreInfo ProcessorCore;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ProcessorCoreInfo
        {
            public byte Flags;
            public ushort NodeNumber;
            public ushort Reserved;
            public IntPtr ProcessorMask;
        }

        public enum LOGICAL_PROCESSOR_RELATIONSHIP
        {
            RelationProcessorCore,
            RelationNumaNode,
            RelationCache,
            RelationProcessorPackage,
            RelationGroup,
            RelationAll = 0xffff
        }

        [DllImport("kernel32.dll")]
        public static extern bool GetLogicalProcessorInformation(IntPtr Buffer, ref int ReturnLength);

        static int GetProcessorThreadCount()
        {
            int returnLength = 0;
            GetLogicalProcessorInformation(IntPtr.Zero, ref returnLength);

            if (returnLength == 0)
                throw new System.ComponentModel.Win32Exception();

            IntPtr buffer = Marshal.AllocHGlobal(returnLength);
            try
            {
                if (!GetLogicalProcessorInformation(buffer, ref returnLength))
                    throw new System.ComponentModel.Win32Exception();

                int offset = 0;
                int size = Marshal.SizeOf<SYSTEM_LOGICAL_PROCESSOR_INFORMATION>();
                int threadCount = 0;

                while (offset + size <= returnLength)
                {
                    SYSTEM_LOGICAL_PROCESSOR_INFORMATION info = Marshal.PtrToStructure<SYSTEM_LOGICAL_PROCESSOR_INFORMATION>(buffer + offset);
                    if (info.Relationship == (int)LOGICAL_PROCESSOR_RELATIONSHIP.RelationProcessorCore)
                    {
                        ProcessorCoreInfo processorInfo = info.ProcessorInformation.ProcessorCore;
                        int processorCount = CountSetBits(processorInfo.ProcessorMask.ToInt64());
                        threadCount += processorCount;
                    }

                    offset += size;
                }

                return threadCount;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        static int CountSetBits(long i)
        {
            i = i - ((i >> 1) & 0x5555555555555555);
            i = (i & 0x3333333333333333) + ((i >> 2) & 0x3333333333333333);
            return (int)((((i + (i >> 4)) & 0xF0F0F0F0F0F0F0F) * 0x101010101010101) >> 56);
        }
        //*******************************************
        static double BytesToGigabytes(ulong bytes)
        {
            return bytes / (1024.0 * 1024.0 * 1024.0);
        }

        static double GetTotalPhysicalMemoryInGB()
        {
            MEMORYSTATUSEX memoryStatus = new MEMORYSTATUSEX();
            memoryStatus.dwLength = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX));

            if (GlobalMemoryStatusEx(ref memoryStatus))
            {
                return BytesToGigabytes(memoryStatus.ullTotalPhys);
            }
            else
            {
                throw new InvalidOperationException("Failed to retrieve memory information.");
            }
        }
        //********************************************************************

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void GetLocalTime(out SYSTEMTIME systemTime);

        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            public ushort Year;
            public ushort Month;
            public ushort DayOfWeek;
            public ushort Day;
            public ushort Hour;
            public ushort Minute;
            public ushort Second;
            public ushort Milliseconds;
        }

        static string GetCurrentLocalTimeAsString()
        {
            SYSTEMTIME systemTime;
            GetLocalTime(out systemTime);

            return $"GetLocalTime: {systemTime.Hour:D2}:{systemTime.Minute:D2}:{systemTime.Second:D2}";
        }
        //*********************************************************************************

        [DllImport("kernel32.dll")]
        public static extern uint GetTimeZoneInformation(out TIME_ZONE_INFORMATION lpTimeZoneInformation);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct TIME_ZONE_INFORMATION
        {
            public int Bias;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string StandardName;
            public SYSTEMTIME StandardDate;
            public int StandardBias;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string DaylightName;
            public SYSTEMTIME DaylightDate;
            public int DaylightBias;
        }

        static string GetTimeZoneInformationAsString()
        {
            TIME_ZONE_INFORMATION timeZoneInfo;
            uint result = GetTimeZoneInformation(out timeZoneInfo);

            if (result == 0xFFFFFFFF)
            {
                throw new System.ComponentModel.Win32Exception();
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Time Zone Information:");
                sb.AppendLine($"Bias: {timeZoneInfo.Bias} minutes");
                sb.AppendLine($"Standard Name: {timeZoneInfo.StandardName}");
                sb.AppendLine($"Standard Bias: {timeZoneInfo.StandardBias} minutes");
                sb.AppendLine($"Daylight Name: {timeZoneInfo.DaylightName}");
                sb.AppendLine($"Daylight Bias: {timeZoneInfo.DaylightBias} minutes");

                return $"GetTimeZonelnformation: {sb}";
            }
        }
        //******************************************************************************************

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetTimeFormat(uint Locale, uint dwFlags, ref SYSTEMTIME lpTime,
                                string lpFormat, StringBuilder lpTimeStr, int cchTime);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern void GetSystemTime(out SYSTEMTIME lpSystemTime);

        static string GetFormattedTime()
        {
            SYSTEMTIME time;
            GetSystemTime(out time);

            StringBuilder timeStr = new StringBuilder(80); // Инициализируем StringBuilder
            int bufferSize = GetTimeFormat(0, 0, ref time, "HH':'mm':'ss", timeStr, timeStr.Capacity); // Получаем отформатированное время

            if (bufferSize == 0)
            {
                throw new System.ComponentModel.Win32Exception();
            }

            return $"GetTimeFormat: {timeStr}";
        }
        //*********************************************************************************************

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowCursor(bool bShow);
        private void ShowCursorButton(object sender, EventArgs e)
        {
            ShowCursor(false);
            MessageBox.Show("Курсор скрыт");
            System.Threading.Thread.Sleep(3000);

            ShowCursor(true);
            MessageBox.Show("Курсор отображен");
        }
        //*************************************************************************************************

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int GetKeyboardLayoutName([Out] StringBuilder pwszKLID);

        private void GetKeyboardLayouts(object sender, EventArgs e)
        {
            try
            {
                StringBuilder layoutName = new StringBuilder(9); // Предполагаемая длина имени раскладки
                GetKeyboardLayoutName(layoutName);

                string layoutId = layoutName.ToString();
                string layoutNameStr = DecodeKeyboardLayout(layoutId);

                MessageBox.Show($"Keyboard Layout Name: {layoutNameStr}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        static string DecodeKeyboardLayout(string layoutId)
        {
            switch (layoutId)
            {
                case "00000409":
                    return "English (United States)";
                default:
                    return "Unknown Layout";
            }
        }
        //***************************************************************************

        [DllImport("kernel32.dll")]
        static extern uint GetTickCount();

        private void GetTickCountButton(object sender, EventArgs e)
        {
            uint tickCount = GetTickCount();
            MessageBox.Show($"Миллисекунды с момента запуска системы: {tickCount}");
        }
        //*********************************************************************************

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool MessageBeep(uint uType);

        private void MessageBeepButton(object sender, EventArgs e)
        {
            MessageBeep(0xFFFFFFFF);
            MessageBox.Show("Beep sound played successfully!");
        }
        //********************************************************************************
        [DllImport("user32.dll")]
        static extern uint GetSysColor(enums.SystemElementsToColor nIndex);
        [DllImport("user32.dll")]
        static extern bool SetSysColors(int cElements, int[] lpaElements, int[] lpaColors);

        List<ItemColor> listSystemColors = new List<ItemColor>();//список системных цветов
        public void setColor_Btn(object sender, EventArgs e)
        {
            if (cbxColor.SelectedItem != null && cbxSysEl.SelectedItem != null)
            {
                Color newColor = Color.FromName(cbxColor.SelectedItem.ToString());
                SystemElementsToColor item = (SystemElementsToColor)Enum.Parse(typeof(SystemElementsToColor), cbxSysEl.SelectedItem.ToString());

                listSystemColors.ForEach(x =>
                {
                    if (x.ItemName == item.ToString())
                    {
                        label2.Text = "oldColor: ";
                        GetSystemColor();
                        SetSysColors(1, new int[] { (int)item }, new int[] { System.Drawing.ColorTranslator.ToWin32(newColor) });
                        x.HasChanged = true;
                        label2.Text += "\nnewColor: ";
                        GetSystemColor();
                    }
                });

            }
            else { System.Windows.Forms.MessageBox.Show("Invalid enter "); }
        }
        void GetSystemColor()
        {
            if (cbxSysEl.SelectedItem != null)
            {
                // Элемент выбранный из списка
                SystemElementsToColor item = (SystemElementsToColor)Enum.Parse(typeof(SystemElementsToColor), cbxSysEl.SelectedItem.ToString());

                // Возвращает RGB цвет элемента item 
                int color1 = Convert.ToInt32(GetSysColor(item));

                // Преобразование RGB в Color
                Color color = Color.FromArgb(255, (int)(color1 & 0xFF), (int)((color1 & 0xFF00) >> 8), (int)((color1 & 0xFF0000) >> 16));

                string colorName = ColorTranslator.ToHtml(color);
                //MessageBox.Show($"Цвет из RGB to color: {colorName}\n{color1}\n{color}");
                // Проверяем, существует ли цвет в перечислении ColorFromRGB
                ColorFromRGB matchedColor = ColorFromRGB.Red; // Инициализируем с каким-то значением по умолчанию
                foreach (ColorFromRGB enumColor in Enum.GetValues(typeof(ColorFromRGB)))
                {
                    string colorselected = ColorTranslator.ToHtml(Color.FromName("#" + enumColor.ToString("X").Substring(2)));
                    if (colorName.Equals(colorselected, StringComparison.OrdinalIgnoreCase))
                    {
                        matchedColor = enumColor;
                        break;
                    }
                }
                // MessageBox.Show($"Цвет из перечисления: {matchedColor}");
                label2.Text += "\n" + item.ToString() + " " + matchedColor;
            }
        }

        List<ItemColor> saveSystemColors()
        {
            List<ItemColor> list = new List<ItemColor>();//список системных цветов
            foreach (SystemElementsToColor se in cbxSysEl.Items)
            {
                int color1 = Convert.ToInt32(GetSysColor(se));
                Color color = Color.FromArgb(color1 & 0xFF, (color1 & 0xFF00) >> 8, (color1 & 0xFF0000) >> 16);
                list.Add(new ItemColor(se.ToString(), color));

            }
            return list;

        }

        void fillComboBoxes()
        {
            cbxSysEl.DataSource = Enum.GetValues(typeof(enums.SystemElementsToColor));
            cbxSysEl.SelectedItem = null;
            cbxSysEl.Text = "Выберите элемент";
            cbxColor.DataSource = Enum.GetValues(typeof(enums.ColorFromRGB));
            cbxColor.SelectedItem = null;
            cbxColor.Text = "Выберите цвет";
        }
        private void addColornsInCB(object sender, EventArgs e)
        {
            fillComboBoxes();
            listSystemColors = saveSystemColors();
        }
    }
}
