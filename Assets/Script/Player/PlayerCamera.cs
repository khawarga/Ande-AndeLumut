using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform Obj;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - Obj.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Obj.position.x + offset.x, Obj.position.y + offset.y, transform.position.z);
    }
}
