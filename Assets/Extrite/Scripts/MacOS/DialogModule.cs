using UnityEngine;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System;

public class DialogModule : MonoBehaviour {

  #if UNITY_STANDALONE
  public static string WS_WIN32       = "Win32";
  public static string WS_COCOA       = "Cocoa";
  public static string WS_X11_ZENITY  = "Zenity";
  public static string WS_X11_KDIALOG = "KDialog";
  #endif

  #if UNITY_STANDALONE_WIN
  [DllImport("DialogModule.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_OSX
  [DllImport("DialogModule.bundle", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_LINUX
  [DllImport("DialogModule.so", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #endif

  #if UNITY_STANDALONE
  private static extern string widget_get_system();
  #endif

  string WidgetGetSystem() {

    #if UNITY_STANDALONE
    return widget_get_system();
    #else
    return "NaN";
    #endif

  }

  #if UNITY_STANDALONE_WIN
  [DllImport("DialogModule.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_OSX
  [DllImport("DialogModule.bundle", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_LINUX
  [DllImport("DialogModule.so", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #endif

  #if UNITY_STANDALONE
  unsafe private static extern void* widget_get_owner();
  #endif

  unsafe void* WidgetGetOwner() {

    #if UNITY_STANDALONE
    return widget_get_owner();
    #else
    return (void*)0;
    #endif

  }

  #if UNITY_STANDALONE_WIN
  [DllImport("DialogModule.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_OSX
  [DllImport("DialogModule.bundle", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_LINUX
  [DllImport("DialogModule.so", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #endif

  #if UNITY_STANDALONE
  private static extern string widget_get_icon();
  #endif

  string WidgetGetIcon() {

    #if UNITY_STANDALONE
    return widget_get_icon();
    #else
    return "NaN";
    #endif

  }

  #if UNITY_STANDALONE_WIN
  [DllImport("DialogModule.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_OSX
  [DllImport("DialogModule.bundle", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_LINUX
  [DllImport("DialogModule.so", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #endif

  #if UNITY_STANDALONE
  private static extern string widget_get_caption();
  #endif

  string WidgetGetCaption() {

    #if UNITY_STANDALONE
    return widget_get_caption();
    #else
    return "NaN";
    #endif

  }

  #if UNITY_STANDALONE_WIN
  [DllImport("DialogModule.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_OSX
  [DllImport("DialogModule.bundle", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_LINUX
  [DllImport("DialogModule.so", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #endif

  #if UNITY_STANDALONE
  private static extern double widget_set_system(string sys);
  #endif

  double WidgetSetSystem(string Sys) {

    #if UNITY_STANDALONE
    return widget_set_system(Sys);
    #else
    return -1;
    #endif

  }

  #if UNITY_STANDALONE_WIN
  [DllImport("DialogModule.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_OSX
  [DllImport("DialogModule.bundle", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_LINUX
  [DllImport("DialogModule.so", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #endif

  #if UNITY_STANDALONE
  unsafe private static extern double widget_set_owner(void* hwnd);
  #endif

  unsafe double WidgetSetOwner(void* Hwnd) {

    #if UNITY_STANDALONE
    return widget_set_owner(Hwnd);
    #else
    return -1;
    #endif

  }

  #if UNITY_STANDALONE_WIN
  [DllImport("DialogModule.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_OSX
  [DllImport("DialogModule.bundle", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_LINUX
  [DllImport("DialogModule.so", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #endif

  #if UNITY_STANDALONE
  private static extern double widget_set_icon(string icon);
  #endif

  double WidgetSetIcon(string Icon) {

    #if UNITY_STANDALONE
    return widget_set_icon(Icon);
    #else
    return -1;
    #endif

  }

  #if UNITY_STANDALONE_WIN
  [DllImport("DialogModule.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_OSX
  [DllImport("DialogModule.bundle", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_LINUX
  [DllImport("DialogModule.so", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #endif

  #if UNITY_STANDALONE
  private static extern double widget_set_caption(string str);
  #endif

  double WidgetSetCaption(string Str) {

    #if UNITY_STANDALONE
    return widget_set_caption(Str);
    #else
    return -1;
    #endif

  }

  #if UNITY_STANDALONE_WIN
  [DllImport("DialogModule.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_OSX
  [DllImport("DialogModule.bundle", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_LINUX
  [DllImport("DialogModule.so", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #endif

  #if UNITY_STANDALONE
  private static extern double show_message(string str);
  #endif

  double ShowMessage(string Str) {

    #if UNITY_STANDALONE
    return show_message(Str);
    #else
    return -1;
    #endif

  }

  #if UNITY_STANDALONE_WIN
  [DllImport("DialogModule.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_OSX
  [DllImport("DialogModule.bundle", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_LINUX
  [DllImport("DialogModule.so", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #endif

  #if UNITY_STANDALONE
  private static extern double show_message_cancelable(string str);
  #endif

  double ShowMessageCancelable(string Str) {

    #if UNITY_STANDALONE
    return show_message_cancelable(Str);
    #else
    return -1;
    #endif

  }

  #if UNITY_STANDALONE_WIN
  [DllImport("DialogModule.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_OSX
  [DllImport("DialogModule.bundle", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_LINUX
  [DllImport("DialogModule.so", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #endif

  #if UNITY_STANDALONE
  private static extern double show_question(string str);
  #endif

  double ShowQuestion(string Str) {

    #if UNITY_STANDALONE
    return show_question(Str);
    #else
    return -1;
    #endif

  }

  #if UNITY_STANDALONE_WIN
  [DllImport("DialogModule.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_OSX
  [DllImport("DialogModule.bundle", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_LINUX
  [DllImport("DialogModule.so", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #endif

  #if UNITY_STANDALONE
  private static extern double show_question_cancelable(string str);
  #endif

  double ShowQuestionCancelable(string Str) {

    #if UNITY_STANDALONE
    return show_question_cancelable(Str);
    #else
    return -1;
    #endif

  }

  #if UNITY_STANDALONE_WIN
  [DllImport("DialogModule.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_OSX
  [DllImport("DialogModule.bundle", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_LINUX
  [DllImport("DialogModule.so", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #endif

  #if UNITY_STANDALONE
  private static extern double show_attempt(string str);
  #endif

  double ShowAttempt(string Str) {

    #if UNITY_STANDALONE
    return show_attempt(Str);
    #else
    return -1;
    #endif

  }

  #if UNITY_STANDALONE_WIN
  [DllImport("DialogModule.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_OSX
  [DllImport("DialogModule.bundle", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_LINUX
  [DllImport("DialogModule.so", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #endif

  #if UNITY_STANDALONE
  private static extern double show_error(string str, double abort);
  #endif

  double ShowError(string Str, double Abort) {

    #if UNITY_STANDALONE
    return show_error(Str, Abort);
    #else
    return -1;
    #endif

  }

  #if UNITY_STANDALONE_WIN
  [DllImport("DialogModule.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_OSX
  [DllImport("DialogModule.bundle", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_LINUX
  [DllImport("DialogModule.so", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #endif

  #if UNITY_STANDALONE
  private static extern IntPtr get_string(string str, string def);
  #endif

  string Getstring(string Str, string Def) {

    #if UNITY_STANDALONE
    return System.Runtime.InteropServices.Marshal.PtrToStringAnsi(get_string(Str, Def));
    #else
    return "NaN";
    #endif

  }

  #if UNITY_STANDALONE_WIN
  [DllImport("DialogModule.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_OSX
  [DllImport("DialogModule.bundle", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_LINUX
  [DllImport("DialogModule.so", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #endif

  #if UNITY_STANDALONE
  private static extern IntPtr get_password(string str, string def);
  #endif

  string GetPassword(string Str, string Def) {

    #if UNITY_STANDALONE
    return System.Runtime.InteropServices.Marshal.PtrToStringAnsi(get_password(Str, Def));
    #else
    return "NaN";
    #endif

  }

  #if UNITY_STANDALONE_WIN
  [DllImport("DialogModule.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_OSX
  [DllImport("DialogModule.bundle", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_LINUX
  [DllImport("DialogModule.so", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #endif

  #if UNITY_STANDALONE
  private static extern double get_integer(string str, double def);
  #endif

  double GetInteger(string Str, double Def) {

    #if UNITY_STANDALONE
    return get_integer(Str, Def);
    #else
    return -1;
    #endif

  }

  #if UNITY_STANDALONE_WIN
  [DllImport("DialogModule.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_OSX
  [DllImport("DialogModule.bundle", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_LINUX
  [DllImport("DialogModule.so", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #endif

  #if UNITY_STANDALONE
  private static extern double get_passcode(string str, double def);
  #endif

  double GetPasscode(string Str, double Def) {

    #if UNITY_STANDALONE
    return get_passcode(Str, Def);
    #else
    return -1;
    #endif

  }

  #if UNITY_STANDALONE_WIN
  [DllImport("DialogModule.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_OSX
  [DllImport("DialogModule.bundle", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_LINUX
  [DllImport("DialogModule.so", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #endif

  #if UNITY_STANDALONE
  private static extern IntPtr get_open_filename(string filter, string fname);
  #endif

  string GetOpenFileName(string Filter, string FName) {

    #if UNITY_STANDALONE
    return System.Runtime.InteropServices.Marshal.PtrToStringAnsi(get_open_filename(Filter, FName));
    #else
    return "NaN";
    #endif

  }

  #if UNITY_STANDALONE_WIN
  [DllImport("DialogModule.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_OSX
  [DllImport("DialogModule.bundle", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_LINUX
  [DllImport("DialogModule.so", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #endif

  #if UNITY_STANDALONE
  private static extern IntPtr get_open_filename_ext(string filter, string fname, string dir, string title);
  #endif

  string GetOpenFileNameExt(string Filter, string FName, string Dir, string Title) {

    #if UNITY_STANDALONE
    return System.Runtime.InteropServices.Marshal.PtrToStringAnsi(get_open_filename_ext(Filter, FName, Dir, Title));
    #else
    return "NaN";
    #endif

  }

  #if UNITY_STANDALONE_WIN
  [DllImport("DialogModule.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_OSX
  [DllImport("DialogModule.bundle", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_LINUX
  [DllImport("DialogModule.so", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #endif

  #if UNITY_STANDALONE
  private static extern IntPtr get_open_filenames(string filter, string fname);
  #endif

  string GetOpenFileNames(string Filter, string FName)
  {

    #if UNITY_STANDALONE
    return System.Runtime.InteropServices.Marshal.PtrToStringAnsi(get_open_filenames(Filter, FName));
    #else
    return "NaN";
    #endif

  }

  #if UNITY_STANDALONE_WIN
  [DllImport("DialogModule.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_OSX
  [DllImport("DialogModule.bundle", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_LINUX
  [DllImport("DialogModule.so", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #endif

  #if UNITY_STANDALONE
  private static extern IntPtr get_open_filenames_ext(string filter, string fname, string dir, string title);
  #endif

  string GetOpenFileNamesExt(string Filter, string FName, string Dir, string Title)
  {

    #if UNITY_STANDALONE
    return System.Runtime.InteropServices.Marshal.PtrToStringAnsi(get_open_filenames_ext(Filter, FName, Dir, Title));
    #else
    return "NaN";
    #endif

  }

  #if UNITY_STANDALONE_WIN
  [DllImport("DialogModule.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_OSX
  [DllImport("DialogModule.bundle", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_LINUX
  [DllImport("DialogModule.so", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #endif

  #if UNITY_STANDALONE
  private static extern IntPtr get_save_filename(string filter, string fname);
  #endif

  string GetSaveFileName(string Filter, string FName) {

    #if UNITY_STANDALONE
    return System.Runtime.InteropServices.Marshal.PtrToStringAnsi(get_save_filename(Filter, FName));
    #else
    return "NaN";
    #endif

  }

  #if UNITY_STANDALONE_WIN
  [DllImport("DialogModule.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_OSX
  [DllImport("DialogModule.bundle", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_LINUX
  [DllImport("DialogModule.so", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #endif

  #if UNITY_STANDALONE
  private static extern IntPtr get_save_filename_ext(string filter, string fname, string dir, string title);
  #endif

  string GetSaveFileNameExt(string Filter, string FName, string Dir, string Title) {

    #if UNITY_STANDALONE
    return System.Runtime.InteropServices.Marshal.PtrToStringAnsi(get_save_filename_ext(Filter, FName, Dir, Title));
    #else
    return "NaN";
    #endif

  }

  #if UNITY_STANDALONE_WIN
  [DllImport("DialogModule.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_OSX
  [DllImport("DialogModule.bundle", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_LINUX
  [DllImport("DialogModule.so", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #endif

  #if UNITY_STANDALONE
  private static extern IntPtr get_directory(string dname);
  #endif

  string GetDirectory(string DName) {

    #if UNITY_STANDALONE
    return System.Runtime.InteropServices.Marshal.PtrToStringAnsi(get_directory(DName));
    #else
    return "NaN";
    #endif

  }

  #if UNITY_STANDALONE_WIN
  [DllImport("DialogModule.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_OSX
  [DllImport("DialogModule.bundle", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_LINUX
  [DllImport("DialogModule.so", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #endif

  #if UNITY_STANDALONE
  private static extern IntPtr get_directory_alt(string capt, string root);
  #endif

  string GetDirectoryAlt(string Capt, string Root) {

    #if UNITY_STANDALONE
    return System.Runtime.InteropServices.Marshal.PtrToStringAnsi(get_directory_alt(Capt, Root));
    #else
    return "NaN";
    #endif

  }

  #if UNITY_STANDALONE_WIN
  [DllImport("DialogModule.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_OSX
  [DllImport("DialogModule.bundle", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_LINUX
  [DllImport("DialogModule.so", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #endif

  #if UNITY_STANDALONE
  private static extern double get_color(double defcol);
  #endif

  double GetColor(double DefCol) {

    #if UNITY_STANDALONE
    return get_color(DefCol);
    #else
    return -1;
    #endif

  }

  #if UNITY_STANDALONE_WIN
  [DllImport("DialogModule.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_OSX
  [DllImport("DialogModule.bundle", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #elif UNITY_STANDALONE_LINUX
  [DllImport("DialogModule.so", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
  #endif

  #if UNITY_STANDALONE
  private static extern double get_color_ext(double defcol, string title);
  #endif

  double GetColorExt(double DefCol, string Title) {

    #if UNITY_STANDALONE
    return get_color_ext(DefCol, Title);
    #else
    return -1;
    #endif

  }

  void Start() {

    WidgetSetCaption("DialogModule");
    string Str = ShowMessage("Hello World!").ToString();
    ShowMessage(Str);

    Str = ShowMessageCancelable("Hello World!").ToString();
    ShowMessage(Str);

    Str = ShowQuestion("Yes or no?").ToString();
    ShowMessage(Str);

    Str = ShowQuestionCancelable("Yes, no, or cancel?").ToString();
    ShowMessage(Str);

    WidgetSetCaption("Error");
    Str = ShowAttempt("Hello World!").ToString();
    WidgetSetCaption("DialogModule");
    ShowMessage(Str);

    WidgetSetCaption("Error");
    Str = ShowError("Hello World!", 0).ToString();
    WidgetSetCaption("DialogModule");
    ShowMessage(Str);

    Str = Getstring("Enter a string:", "Hello World!");
    if (Str != "") ShowMessage(Str);

    Str = GetPassword("Enter a string password:", "Hello World!");
    if (Str != "") ShowMessage(Str);

    Str = GetInteger("Enter an integer:", 0).ToString();
    ShowMessage(Str);

    Str = GetPasscode("Enter an integer passcode:", 0).ToString();
    ShowMessage(Str);

    string Filter = "Sprite Images (*.png *.gif *.jpg *.jpeg)|*.png;*.gif;*.jpg;*.jpeg|Background Images (*.png)|*.png|All Files (*.*)|*.*";

    Str = GetOpenFileName(Filter, "Select a File");
    if (Str != "") ShowMessage(Str);

    Str = GetOpenFileNameExt(Filter, "Select a File", "", "Open Ext");
    if (Str != "") ShowMessage(Str);

    Str = GetOpenFileNames(Filter, "Select Files");
    if (Str != "") ShowMessage(Str);

    Str = GetOpenFileNamesExt(Filter, "Select Files", "", "Open Ext");
    if (Str != "") ShowMessage(Str);

    Str = GetSaveFileName(Filter, "Untitled.png");
    if (Str != "") ShowMessage(Str);

    Str = GetSaveFileNameExt(Filter, "Untitled.png", "", "Save As Ext");
    if (Str != "") if (Str != "") ShowMessage(Str);

    Str = GetDirectory("");
    if (Str != "") ShowMessage(Str);

    Str = GetDirectoryAlt("Get Directory Alt", "");
    if (Str != "") ShowMessage(Str);

    double CRed = 255;

    Str = GetColor(CRed).ToString();
    ShowMessage(Str);

    #if UNITY_STANDALONE_OSX
    string title = "Colors Ext";
    #else
    string title = "Color Ext";
    #endif

    Str = GetColorExt(CRed, title).ToString();
    ShowMessage(Str);

    Application.Quit();

  }

  void Update() {

  }
}