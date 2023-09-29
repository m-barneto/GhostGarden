using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class PuzzleInput : MonoBehaviour {
    public AspectBase selectedAspect;
    public Tilemap aspectMap;
    public Tilemap puzzleMap;

    public AudioClip write1;
    public AudioClip write2;
    public AudioClip erase;

    private Camera cam;
    private AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        cam = Camera.main;
    }

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int tilePos = aspectMap.WorldToCell(mousePos);
            if (!aspectMap.GetTile(tilePos)) {
                //aspectMap.SetTile(tilePos, selectedAspect.tile);
                //aspectMap.SetTile(Vector3Int.one, selectedAspect.tile);
            }
        }
    }

    public void OnDragEnd(PointerEventData eventData) {
        AspectBase aspect = eventData.pointerDrag.GetComponent<Draggable>().aspect;

        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int tilePos = aspectMap.WorldToCell(mousePos);
        if (!aspectMap.GetTile(tilePos) && puzzleMap.GetTile(tilePos) != null) {
            aspectMap.SetTile(tilePos, aspect.tile);
            audioSource.PlayOneShot(Random.value > .5f ? write1 : write2);
            //aspectMap.SetTile(Vector3Int.one, selectedAspect.tile);
        }
    }
}
