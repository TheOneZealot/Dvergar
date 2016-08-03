using UnityEngine;
using System.Collections;

public class World : MonoBehaviour
{
	public WorldData data;

	// Use this for initialization
	void Start ()
	{
		if (data != null)
		{
			GameObject newGameObject = new GameObject("Chunk");
			Chunk newChunk = newGameObject.AddComponent<Chunk>();
			newChunk.data = new ChunkData(data, 0, 0);
			newChunk.Initialize();
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
