using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onDoorwayTriggerEnter += OnDoorwayOpen;
    }

    // Update is called once per frame
    void OnDoorwayOpen()
    {
        
    }
}
