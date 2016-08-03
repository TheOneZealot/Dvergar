using UnityEngine;
using System.Collections.Generic;

public class WorldData
{
	public int chunkSize = 16;
	public int chunkHeight = 256;
	public Dictionary<Vector2, ChunkData> chunks;
}
