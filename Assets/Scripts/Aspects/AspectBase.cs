using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Aspect", menuName = "ScriptableObjects/Aspect", order = 1)]
public class AspectBase : ScriptableObject {
    public string Name;
    public string Desc;
    public Tile tile;
    public AspectBase Component1 = null;
    public AspectBase Component2 = null;
    public bool IsPrimal {
        get {
            return Component1 != null && Component2 != null;
        }
    }

    public bool CanConnect(AspectBase aspect) {
        if (Component1 == aspect || Component2 == aspect) {
            return true;
        }
        return false;
    }
}
