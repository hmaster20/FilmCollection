using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FC.Provider
{
    public static class InputLanguages
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr GetKeyboardLayout(int WindowsThreadProcessID);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetWindowThreadProcessId(IntPtr handleWindow, out int lpdwProcessID);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetForegroundWindow();

        private static InputLanguageCollection _InstalledInputLanguages;
        // Идентификатор активного потока
        private static int _ProcessId;
        // Текущий язык ввода
        private static string _CurrentInputLanguage;

        public static string GetKeyboardLayoutId()
        {
            _InstalledInputLanguages = InputLanguage.InstalledInputLanguages;

            // Получаем хендл активного окна
            IntPtr hWnd = GetForegroundWindow();

            // Получаем номер потока активного окна
            int WinThreadProcId = GetWindowThreadProcessId(hWnd, out _ProcessId);

            // Получаем раскладку
            IntPtr KeybLayout = GetKeyboardLayout(WinThreadProcId);

            // Циклом перебираем все установленные языки для проверки идентификатора
            for (int i = 0; i < _InstalledInputLanguages.Count; i++)
            {
                if (KeybLayout == _InstalledInputLanguages[i].Handle)
                {
                    _CurrentInputLanguage = _InstalledInputLanguages[i].Culture.ThreeLetterWindowsLanguageName.ToString();
                }
            }
            return _CurrentInputLanguage;
        }
    }
}
