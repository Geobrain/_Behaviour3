using System;
using System.Collections.Generic;

public sealed class Data
{
	public static int lastDataComponentID;
	public object[] Nodes = new object[6];

	public T Add<T>() where T : new()
	{
		if (Indexer<T>.Id == -1)
			Indexer<T>.Id = ++lastDataComponentID;

		if (Indexer<T>.Id >= Nodes.Length)
			Array.Resize(ref Nodes, Indexer<T>.Id << 1);

		var o = new T();
		Nodes[Indexer<T>.Id] = o;
		return o;
	}
	public T Add<T>(T obj)
	{
		if (Indexer<T>.Id == -1)
			Indexer<T>.Id = ++lastDataComponentID;

		if (Indexer<T>.Id >= Nodes.Length)
			Array.Resize(ref Nodes, Indexer<T>.Id << 1);

		Nodes[Indexer<T>.Id] = obj;
		return obj;
	}

	public static class Indexer<T>
	{
		public static int Id = -1;
	}
}

public static class DataSource
{
	public static Dictionary<Ent, Data> Source = new ();

	public static void RemoveData(this Ent entity) 
		=> Source.Remove(entity);

	public static Data Set(this Ent entity, Data obj)
	{
		Source[entity] = obj;
		return obj;
	}
	
}

