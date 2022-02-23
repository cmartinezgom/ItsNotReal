<<<<<<< Updated upstream
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryOverTime : MonoBehaviour
{
    public float timeToDestroy;

    float t = 0.0f;

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        if (t >= timeToDestroy)
        {
            Destroy(gameObject);
        }
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryOverTime : MonoBehaviour
{
    public float timeToDestroy;

    float t = 0.0f;

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        if (t >= timeToDestroy)
        {
            Destroy(gameObject);
        }
    }
}
>>>>>>> Stashed changes
