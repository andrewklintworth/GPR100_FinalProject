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
        hitBoxPath = new Vector3[lineLength - 1];
        
        for (int i = 1; i < lineLength; i++)
        {
            hitBoxPath[i - 1] = gameObject.GetComponent<LineRenderer>().GetPosition(i);
        }
    }

    private void Update()
    {
        if (transform.childCount == 1)
        {
            Vector3 hitPos = hitBox.transform.localPosition;
            float distanceTo = Vector3.Distance(hitPos, hitBoxPath[indexInPath]);

            if (distanceTo <= Speed*Time.deltaTime)
            {
                hitPos = hitBoxPath[indexInPath];
                indexInPath++;
                if (indexInPath > lineLength - 2) { destroySelf(); }
                else { hitPos += (hitBoxPath[indexInPath] - hitPos).normalized * (Speed*Time.deltaTime - distanceTo); }

            }
            else
            {
                hitPos += (hitBoxPath[indexInPath] - hitPos).normalized * (Speed * Time.deltaTime);
            }
            hitBox.transform.localPosition = hitPos;
        }
    }

    public void destroySelf()
    {
        Destroy(gameObject);
    }

    public Vector3 retreiveDirection()
    {
        Vector3 hitPos = hitBox.transform.localPosition;
        if(indexInPath>lineLength-2) { return hitPos += (hitBoxPath[indexInPath-1] - hitPos).normalized; }
        return hitPos += (hitBoxPath[indexInPath] - hitPos).normalized;
    }
}
