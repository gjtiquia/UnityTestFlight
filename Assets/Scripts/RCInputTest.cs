using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCInputTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Event.GetEventCount() > 1)
        {
            Debug.Log(Event.GetEventCount());
            Event outEvent = new Event();
            Event.PopEvent(outEvent);
            Debug.Log(outEvent);
        }
    }
}
