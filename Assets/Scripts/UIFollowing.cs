using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowing : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = GameObject.Find("XR Rig").transform.position + new Vector3(0, -0.6f, 1.594f);
        gameObject.transform.rotation = GameObject.Find("XR Rig").transform.rotation;
    }
}
