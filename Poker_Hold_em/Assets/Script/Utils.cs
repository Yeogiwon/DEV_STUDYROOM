using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PRS
{
    public Vector3 pos;
    public Quaternion rot;
    public Vector3 scale;

    public PRS(Vector3 pos, Quaternion rot, Vector3 scale)
    {
        this.pos = pos;
        this.rot = rot;
        this.scale = scale;
    }

    public PRS(GameObject gameObject)
    {
        this.pos = gameObject.transform.position;
        this.rot = gameObject.transform.rotation;
        this.scale = gameObject.transform.localScale;
    }
    
}

public class Utils
{
    public static Quaternion QI => Quaternion.identity;
    public static Quaternion QJ => Quaternion.EulerAngles(1.5708f,0,0);
}
