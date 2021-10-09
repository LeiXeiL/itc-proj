using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInfo : MonoBehaviour
{
    [SerializeField] private bool isOpen;
    [SerializeField] private Vector3 OpenRotateTo;
    private Vector3 StartRot;

    public void OpenClose()
    {
        if (!isOpen)
        {
            if (transform.parent.gameObject != null)
            {
                var prtn = transform.parent.gameObject;
                prtn.transform.rotation = Quaternion.Euler(OpenRotateTo.x, OpenRotateTo.y, OpenRotateTo.z);
            }
            else
            {
                transform.rotation = Quaternion.Euler(OpenRotateTo.x, OpenRotateTo.y, OpenRotateTo.z);
            }
            isOpen = true;
        }
        else if (isOpen)
        {

            if (transform.parent.gameObject != null)
            {
                var prtn = transform.parent.gameObject;
                prtn.transform.rotation = Quaternion.Euler(StartRot.x, StartRot.y, StartRot.z);
            }
            else
            {
                transform.rotation = Quaternion.Euler(StartRot.x, StartRot.y, StartRot.z);
            }
            isOpen = false;
        }
    }
}
