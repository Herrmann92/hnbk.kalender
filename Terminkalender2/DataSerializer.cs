using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Terminkalender2
{
	public class DataSerializer
	{
		public DataSerializer ()
		{
		}

		public static Data deserialize(String path) {
			Data d = null;

			IFormatter formatter = new BinaryFormatter ();

			Stream stream = new FileStream (path, FileMode.Open, FileAccess.Read, FileShare.Read);
			try {
				d = formatter.Deserialize(stream) as Data;
			} catch(Exception e) {
				Console.WriteLine ("Error while deserializing data in file " + path);
				Console.WriteLine(e.Data);
			} finally {
				stream.Close ();
			}

			return d;

		}

		public static void serialize(String path, Data d) {
			IFormatter formatter = new BinaryFormatter ();

			Stream stream = new FileStream (path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
			formatter.Serialize (stream, d);
			stream.Close();
		}
	}
}

