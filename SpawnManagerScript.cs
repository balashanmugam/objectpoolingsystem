using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//spawns objects 
public class SpawnManagerScript : MonoBehaviour
{
    //Singleton pattern because there is going to be only one instance of the SpawnManagerScript
    public static SpawnManagerScript instance;

    // delegate takes no parameters and returns void
    public delegate void Recycle();

    // static event to be called when the object reaches out of the screen.
    public static event Recycle OnRecycle;

    // Two modes to demonstrate the object pooling. 
    // If false - Then the objects do not respawn randomly, can be used to showcase how the object pooling is done.
    // if true - Then the objects spawn randomly and random position.
    public bool autoRecycle;

    private void Awake()
    {
        instance = this;   
    }
    // check for input key.
    void Update()
    {
        // Space to spawn asteroids
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = (GameObject)ObjectPoolingSystem.instance.GetObject();
            if (obj != null)
            {
                obj.SetActive(true);
                obj.GetComponent<AsteroidDestroyScript>().enabled = false;
            }


        }
        // When no asteroids are created.
        if (OnRecycle != null)
        {
            OnRecycle();
        }
    }
}
