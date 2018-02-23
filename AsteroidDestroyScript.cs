using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDestroyScript : MonoBehaviour {
    
    [SerializeField]
    private SpawnManagerScript _spawnManager; // Drag the SpawnManager prefab in the Inspector. 

    // on enable, subscribe to our own Destroy
    void OnEnable()
    {   

        SpawnManagerScript.OnRecycle += Destroy;
    }

    //  Unsubscribe from the event.
    private void OnDisable()
    {
        SpawnManagerScript.OnRecycle -= Destroy;
        CancelInvoke();
        this.enabled = false;
    }

    // custom destroy which disables object
    void Destroy()
    {
        this.gameObject.SetActive(false);
        if(SpawnManagerScript.instance.autoRecycle == true)
        {
            Invoke("Respawn", 0.25f);
        }

    }

    // randomly spawns the asteroid from the object pooling system.
    void Respawn()
    {
        GameObject obj = ObjectPoolingSystem.instance.GetObject();
        if(obj != null)
        {
            Vector3 spawnPoint = new Vector3(Random.Range(7.6f, -7.6f), Random.Range(3.63f, -3.63f), 0);
            obj.transform.position = spawnPoint;
            obj.SetActive(true);
        }

    }
  
}
