using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    public GameObject pl;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && gameObject.tag == "portal1")
            pl.transform.position = pos2.transform.position;
        else if (other.tag == "Player" && gameObject.tag == "portal2"
            && player.isKey)
            pl.transform.position = pos1.transform.position;
    }
}
