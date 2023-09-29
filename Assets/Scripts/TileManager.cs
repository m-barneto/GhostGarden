using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {
    private static TileManager instance;
    public static TileManager Instance { get { return instance; } }

    public List<AspectBase> aspects;
    public AspectBase unknown;

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
    }
    public AspectBase GetAspect(string name) {
        foreach (AspectBase aspect in aspects) {
            if (aspect.Name.ToLower().Equals(name.ToLower())) {
                return aspect;
            }
        }
        return unknown;
    }
}
