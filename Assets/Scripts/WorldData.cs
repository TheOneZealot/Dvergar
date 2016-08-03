using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class WorldData
{
    public static readonly Vector2[] neighborDirections = new Vector2[4] {
        new Vector2(-1, 0), new Vector2(0, 1),
        new Vector2(1, 0), new Vector2(0, -1)
    };

	public int chunkSize = 16;
	public int chunkHeight = 256;
	public Dictionary<Vector2, ChunkData> chunks;

    public WorldData()
    {
        chunks = new Dictionary<Vector2, ChunkData>();
    }

    public bool TryGetChunk(int x, int y, out ChunkData chunk)
    {
        return chunks.TryGetValue(new Vector2(x, y), out chunk);
    }

    public bool[] TryGetChunkNeighbors(int x, int y, out ChunkData[] chunkNeighbors)
    {
        bool[] foundResult = new bool[4];
        chunkNeighbors = new ChunkData[4];

        for(int i = 0; i < neighborDirections.Length; i++)
        {
            Vector2 dir = neighborDirections[i];
            foundResult[i] = TryGetChunk(Mathf.RoundToInt(x + dir.x), Mathf.RoundToInt(y + dir.y), out chunkNeighbors[i]);
        }

        return foundResult;
    }
}
