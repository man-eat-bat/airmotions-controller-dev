using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using System.Threading;

public class accel : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool est_potok = false;
    private static float last_update;
    private static Timer timer;
    private Gyroscope g;


    private void OnMouseDrag()
    {

        
    }
  
    private void OnMouseDown()
    {
      
       est_potok = true; 
            
        
    }
    void Start()
    {
        timer = new Timer();
        updateTime();
        g = Input.gyro;
    }
   

    // Update is called once per frame
    static public void updateTime()
    {
        last_update = timer.Time;
    }
    void Update()
    {
        
        if (est_potok)
        {
            Vector3 t = Input.acceleration;
            Quaternion quatr = g.attitude;
            Quaternion inversequatr = Quaternion.Inverse(quatr);


            //Vector3 accelvec = g.userAcceleration;


            //inversequatr = inversequatr * accelvec;
            Vector3 accelglobal = quatr * g.userAcceleration;
            Vector3 coord = inercial.Step(accelglobal, timer.Time - last_update);
            updateTime();
            if (!Input.gyro.enabled)
            {
                Debug.Log("aviable\n");
                Input.gyro.enabled = true;
            }
            string str = "  -{";
            str = str + "coord:{x: " + coord.x.ToString("f5", CultureInfo.InvariantCulture) + ", y: " + coord.y.ToString("f5", CultureInfo.InvariantCulture) + ", z: " + coord.z.ToString("f5", CultureInfo.InvariantCulture) + "}, ";
            str = str + "a:{x: " + accelglobal.x.ToString("f5", CultureInfo.InvariantCulture) + ", y: " + accelglobal.y.ToString("f5", CultureInfo.InvariantCulture) + ", z: " + accelglobal.z.ToString("f5", CultureInfo.InvariantCulture) + "}, ";
            str = str + "q: {x: " + quatr.x.ToString("f5", CultureInfo.InvariantCulture) + ", y: " + quatr.y.ToString("f5", CultureInfo.InvariantCulture) + ", z: " + quatr.z.ToString("f5", CultureInfo.InvariantCulture) + ", w: " + quatr.w.ToString("f5", CultureInfo.InvariantCulture) + "}";
            str = str + "}\n";
            SocketClient.Send(str);
        }
    }
}
