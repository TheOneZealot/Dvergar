using UnityEngine;
using System.Collections;

[System.Serializable]
public class ChunkData
{
    public static readonly Vector3[] neighborDirections = new Vector3[6] {
        new Vector3(-1, 0, 0), new Vector3(0, 1, 0),
        new Vector3(1, 0, 0), new Vector3(0, -1, 0),
        new Vector3(0, 0, -1), new Vector3(0, 0, 1)
    };

    public WorldData worldData;
    public string[] blocks;
    public ChunkData[] neighbors;

    public Vector2 position;

    public int size { get { return worldData.chunkSize; } }
    public int height { get { return worldData.chunkHeight; } }

    public ChunkData(WorldData worldData, int posX, int posY)
    {
        position = new Vector2(posX, posY);

        this.worldData = worldData;
        worldData.chunks.Add(position, this);

        blocks = new string[size * size * height];
        for (int y = 0; y < height; y++)
        {
            for (int z = 0; z < size; z++)
            {
                for (int x = 0; x < size; x++)
                {
                    blocks[GetBlockIndex(x, y, z)] = "air";
                    if (y < height / 2)
                    {
                        blocks[GetBlockIndex(x, y, z)] = "stone";
                    }
                }
            }
        }

        neighbors = new ChunkData[4];
    }

    int GetBlockIndex(int x, int y, int z)
    {
        return x + z * size + y * size * size;
    }

    public string GetBlock(int x, int y, int z)
    {
        if (x >= size || x < 0 || y >= height || y < 0 || z >= size || z < 0) return "none";

        return blocks[GetBlockIndex(x, y, z)];
    }

    public string[] GetBlockNeighbors(int x, int y, int z)
    {
        string[] result = new string[6];
        for (int i = 0; i < result.Length; i++)
        {
            Vector3 dir = neighborDirections[i];
            result[i] = GetBlock(Mathf.RoundToInt(x + dir.x), Mathf.RoundToInt(y + dir.y), Mathf.RoundToInt(z + dir.z));
        }
        return result;
    }
}
