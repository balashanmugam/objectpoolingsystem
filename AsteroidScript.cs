using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    // Speed at which the asteroid moves.
    [SerializeField]
    private float _velocity;

    // Displacement in x axis
    private float _xDisplacement;

    // Displacement in y axis
    private float _yDisplacement;

    // handler to the destroy script
    private AsteroidDestroyScript _destroyScript;

    // call once when the asteroid is fabricated.
    private void Awake()
    {
        _destroyScript = GetComponent<AsteroidDestroyScript>();
    }

    // Inits all the randomnesss of the asteroid
    private void OnEnable()
    {

        Vector3 spawnPoint = new Vector3(Random.Range(7.6f, -7.6f), Random.Range(3.63f, -3.63f), 0);
        transform.position = spawnPoint;

        // init  
        _xDisplacement = Random.Range(-2f, 2f);
        _yDisplacement = Random.Range(-2f, 2f);

        _velocity = Random.Range(1f, 2f);

    }
    // Update is called once per frame
    void Update()
    {

        // Movement is random.
        transform.Translate(new Vector3(_xDisplacement, _yDisplacement, 0) * _velocity * Time.deltaTime);

        // check if the asteroid has reached out of bounds.
        if (transform.position.x > 9.24f || transform.position.x < -9.24f ||
            transform.position.y > 5.65f || transform.position.y < -5.65f)
        {
            // enable the destroy script.
            _destroyScript.enabled = true;
        }

    }
}
