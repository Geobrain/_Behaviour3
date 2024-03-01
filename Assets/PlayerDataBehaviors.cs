using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[System.Serializable]
sealed class PlayerDataBehaviors
{
    public List<AbstractBehavior> behaviors = new();
}

#region HELPERS   

static partial class DataHelper
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static PlayerDataBehaviors PlayerDataBehaviors(this Ent entity) => DataSource.Source[entity].Nodes[Data.Indexer<PlayerDataBehaviors>.Id] as PlayerDataBehaviors;
}

#endregion