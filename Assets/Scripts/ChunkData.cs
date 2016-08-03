using UnityEngine;
using System.Collections;

public class ChunkData
{
	public WorldData worldData;
	public string[] blocks;

	public int size { get { return worldData.chunkSize; } }
	public int height { get { return worldData.chunkHeight; } }

	public ChunkData(WorldData worldData, int posX, int posY)
	{
		this.worldData = worldData;
		worldData.chunks.Add(new Vector2(posX, posY), this);

		blocks = new string[size * size * height]();
		for (int y = 0; y < height; y++) {
			for (int z = 0; z < size; z++) {
				for (int x = 0; x < size; x++) {
					if (y < height / 2) {
						blocks.SetValue("stone", GetBlockIndex(x, y, z));
					}
				}
			}
		}
	}

	int GetBlockIndex(int x, int y, int z)
	{
		return x + z * size + y * size * size;
	}
}
