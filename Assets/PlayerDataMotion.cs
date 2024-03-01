using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[System.Serializable]
sealed class DataMotion
{
    public float speedWalk;
    public float speedRun;
    public float speedRush;
}

#region HELPERS   

static partial class Components
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static DataMotion DataMotion(this Ent entity) => DataSource.Source[entity].Nodes[Data.Indexer<DataMotion>.Id] as DataMotion;
}

#endregion