using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PuzzleGrid : MonoBehaviour {
    public Tilemap puzzleMap;
    public Tilemap aspectMap;
    public TileManager tileManager;

    // Start is called before the first frame update
    void Start() {
        Vector3 center = Camera.main.ScreenToWorldPoint(new Vector3(.5f * Camera.main.pixelWidth, .5f * Camera.main.pixelHeight, 0f));

        Vector3Int start = new Vector3Int((int)center.x, (int)center.y, (int)center.z);

        foreach (var pos in puzzleMap.cellBounds.allPositionsWithin) {
            Vector3Int tilePos = new Vector3Int(pos.x, pos.y, pos.z);
            if (puzzleMap.HasTile(tilePos)) {
                Debug.Log(tilePos.ToString());
                if (Random.value >= .8f) {
                    aspectMap.SetTile(tilePos, tileManager.GetAspect("Perditio").tile);
                }
            }
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
