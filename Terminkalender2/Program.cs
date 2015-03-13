using System;
using System.IO;


namespace Terminkalender2
{
	/// <summary>
	/// Haupklasse mit statischer Main-Methode
	/// </summary>
	class MainClass
	{
		/*
		 * statische Variablen zur ausführung: -Speicher-pfad und Daten-Objet 
		 */
		private static String datapath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/terminkalender.data";
		public static Data data = new Data();

		public static int Main (string[] args) {

			mainLoop ();
			return 0;
		}

		/// <summary>
		/// Haupt Eingabe-Loop
		/// </summary>
		private static void mainLoop() {

			//Daten einmalig vor start der eigentlichen Anwedung laden und deserialisieren
			load ();
			new MainLoop (data, datapath).execute ();
		}

		//Daten laden und deserialisieren
		public static void load() {
			data = DataSerializer.deserialize (datapath);
		}

		//Daten serialisieren und speichern
		public static void save() {
			DataSerializer.serialize (datapath, data);
		}

		/// <summary>
		/// Reads a date and nothing but a date!
		/// </summary>
		/// <returns>The date.</returns>
		/// <param name="str">String.</param>
		public static DateTime readDate(String str) {
			DateTime dt;
			Console.WriteLine (str);
			try {
				dt = DateTime.Parse(Console.ReadLine());
			} catch(Exception e) {
				dt = readDate (str);
			}

			return dt;
		}

		/// <summary>
		/// Reads an Int and nothing but an Int!
		/// </summary>
		/// <returns>The int.</returns>
		/// <param name="str">String.</param>
		public static int readInt(String str) {
			int i;
			Console.WriteLine (str);
			try {
				i = Int32.Parse(Console.ReadLine());
			} catch(Exception e) {
				i = readInt (str);
			}

			return i;
		}
			
	}
}
