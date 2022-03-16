using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CameraMove : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] GameObject target;
    [SerializeField] Transform gap;
    [SerializeField] Transform EndingPoint1;
    [SerializeField] Transform EndingPoint2;
    public bool following = true;

    private void Start()
    {
        gap.position = new Vector3 (0, -4, 15);
    }


    private void Update()
    {
        if(following)
        {
            camera.transform.position  = target.transform.position - gap.position;
        }
        
        if(target.gameObject.transform.position.x > EndingPoint1.position.x)
        {
            camera.transform.position = EndingPoint1.position - gap.position;
            following = false;
        }
        if (target.gameObject.transform.position.x < EndingPoint2.position.x)
        {
            camera.transform.position = EndingPoint2.position - gap.position;
            following = false;
        }
        if(!following)
        {
            if (target.gameObject.transform.position.x < EndingPoint1.position.x)
            {
                camera.transform.position = EndingPoint2.position - gap.position;
                following = true;
            }
            if (target.gameObject.transform.position.x > EndingPoint2.position.x)
            {
                camera.transform.position = EndingPoint1.position - gap.position;
                following = true;
            }
        }
        
    }




}
