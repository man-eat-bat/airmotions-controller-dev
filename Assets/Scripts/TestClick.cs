using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Net.Sockets;


public class TestClick : MonoBehaviour
{
    // Start is called before the first frame update
    //public Transform test=transform.position;
    private const string TEST_MESSAGE = "  test message\n";
    public inercial inercialka;
    void Start()
    {
       
    }
    private void OnMouseDrag()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            
            transform.position = hit.point;
        }
    
    }
    
    private void OnMouseDown()
    {

        inercial.Stop();
        inercial.Zero();
        accel.est_potok = false;
        accel.updateTime();
        //SocketClient.Send(TEST_MESSAGE);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
