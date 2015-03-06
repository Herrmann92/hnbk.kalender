using System;
using System.Collections.Generic;

namespace Terminkalender2
{
	public class PersonLoop : AbsctractLoop
	{
		public PersonLoop (params Object[] data) : base ("Person", data)
		{
		}

		override protected Dictionary<String, Func<String,bool>> map() {

			Data d = data [0] as Data;

			Dictionary<String, Func<String,bool>> dict = new Dictionary<string, Func<string, bool>> ();
			dict.Add ("list", delegate(string arg) {
				Console.Clear();
				d.personList.ForEach(Console.Out.WriteLine);
				return false;
			});
			dict.Add ("add", delegate(string arg) {
				Console.Clear();
				d.personList.Add (Person.create (d.generatePersonID ()));
				MainClass.save();
				return false;
			});
			dict.Add ("delete", delegate(string arg) {
				Console.Clear();
				Console.WriteLine("ID of person to delete");
				int id = Int32.Parse(Console.ReadLine());
				d.personList.Remove(d.personList.Find(p => p.id == id));
				MainClass.save();
				return false;
			});
			dict.Add ("sort", delegate(string arg) {
				Console.Clear();
				new PersonSortLoop(data).execute();
				return false;
			});
			dict.Add ("seek", delegate(string arg) {
				Console.WriteLine ("Filter eingeben:");
				String filter = Console.ReadLine ();
				d.personList.FindAll (p => p.contains (filter)).ForEach (Console.Out.WriteLine);
				return false;
			});
			dict.Add ("q", delegate(string arg) {
				return true;
			});

			return dict;
		}
	}
}

