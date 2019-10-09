using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMovement : MonoBehaviour
{
    public GameObject endPoint;

    void Start()
    {
        endPoint = GameObject.Find("EndPoint");
        Debug.Log(transform.position);
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, endPoint.transform.position, 0.75f * Time.deltaTime);

        if(transform.localPosition.x < -850)
        {
            Destroy(gameObject);
        }
    }

    public void destroyCheck()
    {
        if(gameObject.transform.position.x > 875 && gameObject.transform.position.x < 1050)
        {
            PlayHandler.scoreAmount++;
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Miss");
        }
    }
}
