using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPoolingSystem : MonoBehaviour {

    // SINGLETON Pattern so that only one instance can exist at a time.
    public static ObjectPoolingSystem instance;

    // amount of objects to be pooled
    public int poolCount = 5;

    // The gameobject to be pooled
    public GameObject objectToBePooled; // drag and drop in the inspector.

    // Is the pool supposed to expand when it reaches it's limits?
    public bool willExpand = false;

    // The list of the pooled objects
    List<GameObject> poolList;

    // similar to a singleton constructor.
    private void Awake()
    {
        instance = this;
    }

    // Create 'poolCount' number of 'objectToBePooled' gameobjects.
    void Start ()
    {
        poolList = new List<GameObject>();

        for (int i = 0; i < poolCount; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToBePooled);
            obj.SetActive(false); 
            poolList.Add(obj);
        }

	}

    // return the instance of a pooled object that is not active in the hierarchy.
    public GameObject GetObject()
    {
        for (int i = 0; i < poolCount; i++)
        {
            if (!poolList[i].activeInHierarchy)
            {
                return poolList[i];
            }

        }
        // If the all the objects in the hierarchy are active,
        // create a new object and then add it to the list.
        // and return that object.
        if (willExpand)
        {
            GameObject obj = (GameObject)Instantiate(objectToBePooled);
            obj.SetActive(false);
            poolList.Add(obj);
            poolCount++;
            return obj;
        }
        return null;
    }

}
