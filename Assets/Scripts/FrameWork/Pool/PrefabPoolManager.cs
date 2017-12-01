using UnityEngine;
using System.Collections;

public class PrefabPoolManager<T> : PoolManager<T> where T : Object, new() {

    private GameObject prefab;

    public PrefabPoolManager(string path) {
        prefab = Resources.Load<GameObject>(path);
    }
    /*
    public override T CreateItem()
    {
        var item = prefab;
        return item;
    }
    */
}
