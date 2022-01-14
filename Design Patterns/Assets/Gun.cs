using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Bullet bullet;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Shoot() {
        //GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
        GameObject bullet = ObjectPool.instance.GetPooledObject();

        if (bullet != null) {
            bullet.transform.position = transform.position;
            bullet.SetActive(true);
        }
    }
}
