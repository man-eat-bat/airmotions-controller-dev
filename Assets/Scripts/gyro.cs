using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public class gyro : MonoBehaviour
{
    private Gyroscope g ;
    private void OnMouseDrag()
    {


        // accelvec=Input.acceleration;

        Quaternion quatr = g.attitude;
        if (!Input.gyro.enabled)
        {
            Debug.Log("abiable\n");
            Input.gyro.enabled = true;
        }
        string str = "  -{";
       // str = str + "a:{x: " + accelvec.x.ToString("f5", CultureInfo.InvariantCulture) + ", y: " + accelvec.y.ToString("f5", CultureInfo.InvariantCulture) + ", z: " + accelvec.z.ToString("f5", CultureInfo.InvariantCulture) + "}, ";
        str = str + "q: {x: " + quatr.x.ToString("f5", CultureInfo.InvariantCulture) + ", y: " + quatr.y.ToString("f5", CultureInfo.InvariantCulture) + ", z: " + quatr.z.ToString("f5", CultureInfo.InvariantCulture) + ", w: " + quatr.w.ToString("f5", CultureInfo.InvariantCulture) + "}";
        str = str + "}\n";
        SocketClient.Send(str);
    }
    // Start is called before the first frame update
    void Start()
    {
        g = Input.gyro;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
