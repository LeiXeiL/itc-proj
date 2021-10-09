using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private GameObject ToHandPos;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 2))
            {
                if (hit.collider.CompareTag("Pickable") && transform.childCount == 1)
                {
                    GameObject item = hit.collider.gameObject;
                    item.transform.SetParent(gameObject.transform);
                    item.transform.position = ToHandPos.transform.position;
                    item.transform.rotation = ToHandPos.transform.rotation;

                    if (item.GetComponent<Rigidbody>() != null)
                    {
                        item.GetComponent<Rigidbody>().isKinematic = true;
                    }
                    if (item.GetComponent<Collider>() != null)
                    {
                        item.GetComponent<Collider>().isTrigger= true;
                    }
                }
                //----------------------------------------------------------------------
                //                            DOOR
                //----------------------------------------------------------------------
                if (hit.collider.CompareTag("Door"))
                {
                    hit.collider.GetComponent<DoorInfo>().OpenClose();
                }
                //----------------------------------------------------------------------
                //----------------------------------------------------------------------
            }
        }
        if (Input.GetKeyDown(KeyCode.Q) && transform.childCount >= 2)
        {
            var item = transform.GetChild(1);
            item.SetParent(null);
            if (item.GetComponent<Rigidbody>() != null)
            {
                item.GetComponent<Rigidbody>().isKinematic = false;
            }
            if (item.GetComponent<Collider>() != null)
            {
                item.GetComponent<Collider>().isTrigger = false;
            }
        }
    }
}
