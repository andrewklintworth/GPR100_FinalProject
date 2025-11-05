using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class HitBoxMove : MonoBehaviour
{
    public float Speed;

    GameObject hitBox;
    Vector3[] hitBoxPath;
    int indexInPath = 0;
    int lineLength;
    // Start is called before the first frame update
    void Awake()
    {
        hitBox = transform.GetChild(0).gameObject;

        lineLength = gameObject.GetComponent<LineRenderer>().positionCount;
        hitBoxPath = new Vector3[lineLength-1];
        for (int i = 1; i < lineLength; i++)
        {
            hitBoxPath[i - 1] = gameObject.GetComponent<LineRenderer>().GetPosition(i);
        }
    }

    void FixedUpdate()
    {
        Vector3 hitPos = hitBox.transform.localPosition;
        hitPos += (hitBoxPath[indexInPath]-hitPos).normalized * Speed;
        hitBox.transform.localPosition = hitPos;

        if (Vector3.Distance(hitPos,hitBoxPath[indexInPath])<Speed*2) { indexInPath++; }
        if (indexInPath > lineLength-2) { destroySelf(); }
    }

    public void destroySelf()
    {
        Destroy(gameObject);
    }
}
