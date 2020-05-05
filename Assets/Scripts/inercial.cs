using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class inercial : MonoBehaviour
{

    const float G = (float)9.81;
    static float[] pos = new float[] { 0, 0, 0 };
    static float[] vel = new float[] { 0, 0, 0 };
    static float[] preAccel = new float[] { 0, 0, 0 };

    static public Vector3 Step(Vector3 newAccel, float t)
    {
        t /= 1000;
        float[] accel = new float[] { newAccel.x * G, newAccel.y * G, newAccel.z * G };
        for (int i = 0; i < 3; i++)
        {
            float delVel = accel[i] - preAccel[i];
            pos[i] += t * (t * (delVel / 6 + preAccel[i] / 2) + vel[i]);
            vel[i] += (delVel / 2 + preAccel[i]) * t;
        }
        preAccel = accel;
        return Pos;
    }
    static public void Stop()
    {
        for (int i = 0; i < 3; i++)
        {
            vel[i] = 0;
            preAccel[i] = 0;
        }
    }
    static public void Zero()
    {
        for(int i =0; i<3;i++)
        {
            pos[i] = 0;
        }
    }
    static public Vector3 Pos
    {
        get
        {
            return new Vector3(pos[0], pos[1], pos[2]);
        }
    }

}
