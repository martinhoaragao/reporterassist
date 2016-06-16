using AppKit;
using System;
using System.Drawing;
using ObjCRuntime;

namespace Mac
{
	static class MainClass
	{
		private static string titulo;
		static void Main (string[] args)
		{
			NSApplication.Init ();
			NSApplication.Main (args);
			titulo = NewWorkMenu.getTitulo();
		}
	}
}
