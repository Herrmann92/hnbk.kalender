using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Terminkalender2
{
	public class PersonList
	{
		private List<Person> list = new List<Person>();

		public PersonList ()
		{
		}

		public void Add(Person p) {
			list.Add (p);
		}

		public void AddRange(IEnumerable<Person> r) {
			list.AddRange (r);
		}


		public void Print() {
			foreach(Person p in list) {
				Console.WriteLine(p);
			}
		}

		public int generateID() {
			int id = 0;
			foreach (Person p in list) {
				if (p.id > id)
					id = p.id;
			}

			id++;
			return id;
		}

		public void save(String path) {
			IFormatter formatter = new BinaryFormatter ();
			foreach (Person p in list) {
				String fname = path + "/Person_" + p.id;
				Stream stream = new FileStream (fname, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
				formatter.Serialize (stream, p);
				stream.Close();
			}
		}

		public void load(String path) {
			list.Clear();

			IFormatter formatter = new BinaryFormatter ();
			foreach(String f in Directory.GetFiles(path)) {

				Stream stream = new FileStream (f, FileMode.Open, FileAccess.Read, FileShare.Read);
				try {
					list.Add(formatter.Deserialize(stream) as Person);
				} catch(Exception e) {
					Console.WriteLine ("Error while deserializing data in file " + f);
					Console.WriteLine(e.Data);
				} finally {
					stream.Close ();
				}
			}


		}



		public PersonList filter() {
			Console.WriteLine ("Filter kriterium");
			String filter = Console.ReadLine ();

			PersonList copy = new PersonList ();

			foreach (Person p in this.list) {
				if(p.contains(filter))
					copy.Add(p);
			}

			return copy;
		}
	}
}

