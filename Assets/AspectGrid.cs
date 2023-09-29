using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AspectGrid : MonoBehaviour {
    [SerializeField] private Canvas canvas;
    [SerializeField] private PuzzleInput puzzleInput;

    [SerializeField] private GameObject aspectPrefab;
    [SerializeField] private TileManager tileManager;

    private void Awake() {
        foreach (var aspect in tileManager.aspects) {
            GameObject aspectItem = Instantiate(aspectPrefab, this.transform);
            aspectItem.name = aspect.name;
            aspectItem.GetComponent<Image>().sprite = aspect.tile.sprite;
            Draggable draggable = aspectItem.GetComponent<Draggable>();
            draggable.aspect = aspect;
            draggable.canvas = canvas;
            draggable.puzzleInput = puzzleInput;
        }
    }
}
