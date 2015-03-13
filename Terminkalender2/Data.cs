using System;
using System.Collections.Generic;

namespace Terminkalender2
{
	/// <summary>
	/// Data-Klasse, die Personen und Termine kapselt, um sie gemeinsam zu (de)serialisiren und zu speichern
	/// </summary>
	[Serializable]
	public class Data
	{
		public List<Person> personList;
		public List<Termin> terminList;

		public Data () {
			personList = new List<Person> ();
			terminList = new List<Termin> ();
		}

		public int generatePersonID() {
			int id = 0;
			foreach (Person p in personList) {
				if (p.id > id)
					id = p.id;
			}
			id++;
			return id;
		}

		public int generateTerminID() {
			int id = 0;
			foreach (Termin t in terminList) {
				if (t.id > id)
					id = t.id;
			}
			id++;
			return id;
		}

	}
}

