using System;

namespace PHolaMundo
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			showMessage ();
			showMessage2 ();
		}
		
		private static void showMessage()
		{
			Console.WriteLine ("Hola Mundo desde monodevelop");
		}
		
		private static void showMessage2()
		{
			Console.WriteLine ("Y adios.");
		}
	}
}
