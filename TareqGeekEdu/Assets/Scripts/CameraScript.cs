using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform PlayerPosition;

    

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(PlayerPosition.position.x, PlayerPosition.position.y, transform.position.z);
    }
}
