using System;
using System.Collections.Generic;

namespace Terminkalender2
{
	/// <summary>
	/// Termin-Loop, zum anlegen, löschen, etc von Terminen
	/// </summary>
	public class TerminLoop : AbsctractLoop
	{
		public TerminLoop (params Object[] data) : base ("Termin", data)
		{
		}

		override protected Dictionary<String, Func<String,bool>> map() {

			Data d = data [0] as Data;

			Dictionary<String, Func<String,bool>> dict = new Dictionary<String, Func<String, bool>> ();
			dict.Add ("list", delegate(string arg) {
				Console.Clear();
				d.terminList.ForEach(Console.Out.WriteLine);
				return false;
			});
			dict.Add ("add", delegate(string arg) {
				Console.Clear();
				d.terminList.Add (Termin.create (d.generateTerminID ()));
				MainClass.save();
				return false;
			});
			dict.Add ("delete", delegate(string arg) {
				Console.Clear();
				Console.WriteLine("ID of termin to delete");
				int id = Int32.Parse(Console.ReadLine());
				d.terminList.Remove(d.terminList.Find(p => p.id == id));
				MainClass.save();
				return false;
			});
			dict.Add ("sort", delegate(string arg) {
				Console.Clear();
				new TerminSortLoop(data).execute();
				return false;
			});
			dict.Add ("seek", delegate(string arg) {
				Console.WriteLine ("Filter eingeben:");
				String filter = Console.ReadLine ();
				d.terminList.FindAll (p => p.contains (filter)).ForEach (Console.Out.WriteLine);
				return false;
			});
			dict.Add ("q", delegate(string arg) {
				return true;
			});

			return dict;
		}
	}
}

