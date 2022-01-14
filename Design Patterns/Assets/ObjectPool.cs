using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    private List<GameObject> pooledObjects = new List<GameObject>();
    int poolAmount = 20;

    [SerializeField] GameObject bulletPrefab;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < poolAmount; i++) {
            GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject() {
        for (int i = 0; i < pooledObjects.Count; i++) {
            if (!pooledObjects[i].activeInHierarchy) {
                return pooledObjects[i];
            }
        }

        return null;
    }
}
