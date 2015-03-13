using System;
using System.Collections.Generic;

namespace Terminkalender2
{
	/// <summary>
	/// Der Main-Loop, um zwischen Termin- und Personen-Modus zu wechseln
	/// </summary>
	public class MainLoop : AbsctractLoop
	{
		public MainLoop (params Object[] data) : base ("Main", data)
		{
		}

		override protected Dictionary<String, Func<String,bool>> map() {
			Dictionary<String, Func<String,bool>> dict = new Dictionary<string, Func<string, bool>> ();
			dict.Add ("termin", delegate(string arg) {
				Console.Clear();
				new TerminLoop(this.data).execute();
				return false;
			});
			dict.Add ("person", delegate(string arg) {
				Console.Clear();
				new PersonLoop(this.data).execute();
				return false;
			});
			dict.Add ("load", delegate(string arg) {
				Console.Clear();
				this.data[0] = DataSerializer.deserialize(this.data[1] as string);
				return false;
			});
			dict.Add ("save", delegate(string arg) {
				Console.Clear();
				DataSerializer.serialize(this.data[1] as string, this.data[0] as Data);
				return false;
			});
			dict.Add ("q", delegate(string arg) {
				return true;
			});

			return dict;
		}
	}
}

