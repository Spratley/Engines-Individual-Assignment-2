using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Bonus - make this class a Singleton!

[System.Serializable]
public class BulletPoolManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int numBullets;
    
    //TODO: create a structure to contain a collection of bullets
    //Not needed

    // Start is called before the first frame update
    void Start()
    {
        // TODO: add a series of bullets to the Bullet Pool
        SingletonPoolManager.GetInstance().InitFilled(bulletPrefab, numBullets);
    }

    //TODO: modify this function to return a bullet from the Pool
    public GameObject GetBullet()
    {
        //TODO: Replace this with some error checking!
        GameObject bullet = SingletonPoolManager.GetInstance().GetObject();
        if (bullet != null)
            return bullet;
        return bullet;
    }

    //TODO: modify this function to reset/return a bullet back to the Pool 
    public void ResetBullet(GameObject bullet)
    {
        SingletonPoolManager.GetInstance().PoolObject(bullet);
    }
}
