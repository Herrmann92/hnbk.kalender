using System;

namespace Terminkalender2
{
	/// <summary>
	/// Personenklasse
	/// </summary>
	[Serializable]
	public class Person
	{
		public int id;
		public String nachname;
		public String vorname;
		public String stadt;
		public int plz;
		public String strasse;

		public Person (int id, String nachname, String vorname, String stadt, int plz, String strasse)
		{
			this.id = id;
			this.nachname = nachname;
			this.vorname = vorname;
			this.stadt = stadt;
			this.plz = plz;
			this.strasse = strasse;
		}

		/// <summary>
		/// Statische Factory-Methode
		/// </summary>
		/// <param name="id">Identifier.</param>
		public static Person create(int id) {
			string nn, vn, st, str;
			int plz;
			Console.WriteLine ("Neue Person hinzufügen");

			Console.WriteLine ("Nachnamen eingeben");
			nn = Console.ReadLine ();

			Console.WriteLine ("Vornamen eingeben");
			vn = Console.ReadLine ();

			Console.WriteLine ("Wohnort (Stadt) eingeben");
			st = Console.ReadLine ();

			plz = MainClass.readInt ("PLZ eingeben");

			Console.WriteLine ("Strasse & Hausnummer eingeben");
			str = Console.ReadLine ();

			return new Person(id, nn, vn, st, plz, str );
		}

		override
		public String ToString() {
			return "(" + id + ")" + nachname + " " + vorname + " - " + strasse + " in " + plz + " " + stadt;
		}

		public bool contains(String match) {
			if (nachname.Contains (match))
				return true;
			if (vorname.Contains (match))
				return true;
			if (stadt.Contains (match))
				return true;
			if (plz.ToString().Contains (match))
				return true;
			if (strasse.Contains (match))
				return true;

			return false;
		}
	}
}

