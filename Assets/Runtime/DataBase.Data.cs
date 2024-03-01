using System;

public sealed class Data
{
	public static int lastDataComponentID;
	public object[] nodes = new object[6];

	public T Add<T>() where T : new()
	{
		if (Indexer<T>.ID == -1)
			Indexer<T>.ID = ++lastDataComponentID;

		if (Indexer<T>.ID >= nodes.Length)
			Array.Resize(ref nodes, Indexer<T>.ID << 1);

		var o = new T();
		nodes[Indexer<T>.ID] = o;
		return o;
	}
	public T Add<T>(T obj)
	{
		if (Indexer<T>.ID == -1)
			Indexer<T>.ID = ++lastDataComponentID;

		if (Indexer<T>.ID >= nodes.Length)
			Array.Resize(ref nodes, Indexer<T>.ID << 1);

		nodes[Indexer<T>.ID] = obj;
		return obj;
	}

	public static class Indexer<T>
	{
		public static int ID = -1;
	}
}

public static class DBHelper
{
	public static Data[] source = new Data[5];

	public static Data Set(this Ent entity, Data obj)
	{
		if (source.Length <= entity.Id)
			Array.Resize(ref source, entity.Id << 1);

		source[entity.Id] = obj;
		return obj;
	}
	
	public static Data DataFrom(this Ent entity, Ent entityFrom)
	{
		if (source.Length <= entity.Id)
			Array.Resize(ref source, entity.Id << 1);

		source[entity.Id] = source[entityFrom.Id];
		return source[entity.Id];
	}
	
}

