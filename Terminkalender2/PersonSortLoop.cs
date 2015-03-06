using System;
using System.Collections.Generic;

namespace Terminkalender2
{
	public class PersonSortLoop : AbsctractLoop
	{
		public PersonSortLoop (params Object[] data) : base("Sortieren", data)
		{
		}

		override protected Dictionary<String, Func<String,bool>> map() {

			Data d = data [0] as Data;

			Dictionary<String, Func<String,bool>> dict = new Dictionary<string, Func<string, bool>> ();
			dict.Add ("lastname", delegate(string arg) {
				Console.Clear();
				d.personList.Sort((p1,p2) => p2.nachname.CompareTo(p1.nachname));
				d.personList.ForEach(Console.Out.WriteLine);
				return false;
			});
			dict.Add ("firstname", delegate(string arg) {
				Console.Clear();
				d.personList.Sort((p1,p2) => p2.vorname.CompareTo(p1.vorname));
				d.personList.ForEach(Console.Out.WriteLine);
				MainClass.save();
				return false;
			});
		
			dict.Add ("q", delegate(string arg) {
				return true;
			});

			return dict;
		}
	}
}

