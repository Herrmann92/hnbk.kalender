using System;
using System.IO;


namespace Terminkalender2
{
	class MainClass
	{
		private static String datapath = "/Users/oliverherrmann/Desktop/terminkalender.data"; //"h:/terminkalender.data";
		public static Data data = new Data();

		public static int Main (string[] args) {
            if(!File.Exists(datapath))
                File.Create(datapath);
			mainLoop ();
			return 0;
		}

		private static void mainLoop() {
			load ();
			new MainLoop (data, datapath).execute ();
		}

		public static void load() {
			data = DataSerializer.deserialize (datapath);
		}

		public static void save() {
			DataSerializer.serialize (datapath, data);
		}

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



		/*
		private static int mainLoop () {
			String input;
			String opt = "Optionen: termin, person, save, load, q";

			while (true) {
				Console.WriteLine (opt);
				input = Console.ReadLine ();

				switch (input) {
				case "termin":
					Console.Clear ();
					//terminLoop (null);
					new TerminLoop (data).execute ();
					Console.Clear ();
					break;
				case "person":
					Console.Clear ();
					personLoop (null);
					Console.Clear ();
					break;			
				case "save":
					DataSerializer.serialize (datapath, data);
					Console.Clear ();
					break;
				case "load":
					data = DataSerializer.deserialize (datapath);
					Console.Clear ();
					break;
				case "q":
					return 0;
				}
			}
		}

		private static int terminLoop(string arg) {
			String input;
			String opt = "Termin: add, list, seek, q";

			while (true) {
				Console.WriteLine (opt);
				input = Console.ReadLine ();

				switch (input) {
				case "add":
					Console.Clear ();
					data.terminList.Add (Termin.create (data.generateTerminID ()));
					Console.Clear ();
					break;
				case "list":
					Console.Clear ();
					data.terminList.ForEach (Console.Out.WriteLine);
					break;
				case "seek":
					Console.Clear ();
					Console.WriteLine ("Filter eingeben:");
					String filter = Console.ReadLine ();
					data.terminList.FindAll (p => p.contains (filter)).ForEach (Console.Out.WriteLine);
					break;				
				case "q":
					return 0;
					break;
				}
			}
		}

		private static int personLoop (string arg)
		{
			String input;
			String opt = "Person: add, list, seek, q";

			while (true) {
				Console.WriteLine (opt);
				input = Console.ReadLine ();

				switch (input) {
				case "add":
					Console.Clear ();
					data.personList.Add (Person.create (data.generatePersonID()));
					Console.Clear ();
					break;
				case "list":
					Console.Clear ();
					data.personList.ForEach (Console.Out.WriteLine);
					break;
				case "seek":
					Console.Clear ();
					Console.WriteLine ("Filter eingeben:");
					String filter = Console.ReadLine ();
					data.personList.FindAll (p => p.contains (filter)).ForEach (Console.Out.WriteLine);
					break;				
				case "q":
					return 0;
				}
			}
		}
		*/
	}
}
