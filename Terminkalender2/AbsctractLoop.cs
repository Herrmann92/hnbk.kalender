using System;
using System.Collections.Generic;

namespace Terminkalender2
{
	/// <summary>
	/// Abstrakte Basisklasse für einen Command-Line Loop
	/// </summary>
	abstract public class AbsctractLoop
	{
		protected Object[] data;
		protected String name;

		public AbsctractLoop (String name, params Object[] data)
		{
			this.name = name;
			this.data = data;
		}


		/// <summary>
		/// Loop ausführen
		/// </summary>
		public void execute() {
			String input;
			while (true) {
				Console.Out.WriteLine (options());
				input = Console.ReadLine ();
				foreach(KeyValuePair<String, Func<String, bool>> kvp in map()) {
					if (kvp.Key.StartsWith (input)) {
						if (kvp.Value.Invoke (input))
							return;
						break;
					}
				}
			}
		}

		/// <summary>
		/// Dictionary mit Zuordnung zwischen Optionsnamen und Funktionen
		/// </summary>
		protected abstract Dictionary<String, Func<String,bool>> map();

		private String options() {
			return this.name + ": " + String.Join (", ", map ().Keys);

		}
	}
}

