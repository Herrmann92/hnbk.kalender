using System;
using System.Collections.Generic;

namespace Terminkalender2
{
	public class TerminSortLoop : AbsctractLoop
	{
		public TerminSortLoop (params Object[] data) : base("Sorteiren", data)
		{
		}

		override protected Dictionary<String, Func<String,bool>> map() {

			Data d = data [0] as Data;

			Dictionary<String, Func<String,bool>> dict = new Dictionary<string, Func<string, bool>> ();
			dict.Add ("date", delegate(string arg) {
				Console.Clear();
				d.terminList.Sort((p1,p2) => p2.date.CompareTo(p1.date));
				d.terminList.ForEach(Console.Out.WriteLine);
				return false;
			});
			dict.Add ("ort", delegate(string arg) {
				Console.Clear();
				d.terminList.Sort((p1,p2) => p2.ort.CompareTo(p1.ort));
				d.terminList.ForEach(Console.Out.WriteLine);
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

