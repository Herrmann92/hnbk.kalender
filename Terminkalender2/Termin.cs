using System;
using System.Collections.Generic;

namespace Terminkalender2
{
	[Serializable]
	public class Termin
	{
		public int id;
		public int person;
		public DateTime date;
		public String ort;
		public String desc;

		public Termin (int id, int person, DateTime date, String ort, String desc) {
			this.id = id;
			this.person = person;
			this.date = date;
			this.ort = ort;
			this.desc = desc;
		}

		public static Termin create(int id) {
			string ort, desc;
			int person;
			DateTime date;

			Console.WriteLine ("Neuen Termin hinzufügen");

			date = MainClass.readDate("Datum eingeben");

			person = -1;
			while(MainClass.data.personList.Find(p => p.id == person) == null)
				person = MainClass.readInt ("Person(Id) eingeben");

			Console.WriteLine ("Ort eingeben");
			ort = Console.ReadLine ();

			Console.WriteLine ("Beschreibung eingeben");
			desc = Console.ReadLine () ;

			return new Termin(id, person, date, ort, desc);
		}

		override
		public String ToString() {
			return "(" + id + ")" + date + " " + ort + " mit " + person + " - " + desc;
		}

		public bool contains(String match) {
		

			if (id.ToString().Contains (match))
				return true;
			if (person.ToString().Contains (match))
				return true;
			if (date.ToString().Contains (match))
				return true;
			if (ort.Contains (match))
				return true;
			if (desc.Contains (match))
				return true;

			return false;
		}

	}
}

