using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : MonoBehaviour
{
	//public int ExplosionRange = 1;

	public Tilemap tilemap;

	public Tile NotDestructable;
	public Tile destructibleTile;

	public GameObject explosionPrefab;

	public void Explode(Vector2 worldPos, int explosionRadius)
	{
		Vector3Int originCell = tilemap.WorldToCell(worldPos);

		ExplodeCell(originCell);
		bool up = true, down = true, right = true, left = true;
		for(int i = 0; i <= explosionRadius; i++)
        {
			if(!ExplodeCell(originCell + new Vector3Int(i, 0, 0)) && right)
            {
				right = false;
            }
			if(!ExplodeCell(originCell + new Vector3Int(0, i, 0)) && up)
            {
				up = false;
            }
			if(!ExplodeCell(originCell + new Vector3Int(-i, 0, 0)) && left)
            {
				left = false;
            }
			if(!ExplodeCell(originCell + new Vector3Int(0, -i, 0)) && down)
            {
				down = false;
            }
		}


	}

	bool ExplodeCell(Vector3Int cell)
	{
		Tile tile = tilemap.GetTile<Tile>(cell);

		if (tile == NotDestructable)
		{
			return false;
		}

		if (tile == destructibleTile)
		{
			tilemap.SetTile(cell, null);
		}

		Vector3 pos = tilemap.GetCellCenterWorld(cell);
		Destroy(Instantiate(explosionPrefab, pos, Quaternion.identity), 0.33f);

		return true;
	}
}
