using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoolManager <T> where T : Object, new()
{
    private Queue<T> poolQueue;
    private int maxItemCount;

    public PoolManager (int count = 5) {
        poolQueue = new Queue<T>();
        maxItemCount = count;
    }

    public T GetItem() {
        if (poolQueue.Count == 0) {
            T item = CreateItem();
            poolQueue.Enqueue(item);
        }
        return poolQueue.Dequeue();
    }

    public virtual T CreateItem() {
        T item = new T();
        return item;
    }

    public void RecycleItem(T item) {
        if (poolQueue.Count >= maxItemCount)
        {
            Object.Destroy(item);
        }
        else
        {
            poolQueue.Enqueue(item);
        }
    }
}
