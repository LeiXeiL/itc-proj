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
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 3))
            {
                if (hit.collider.CompareTag("Interactable") && transform.childCount == 1)
                {
                    GameObject item = hit.collider.gameObject;
                    item.transform.SetParent(gameObject.transform);
                    //item.transform.position = new Vector3(0.468f, -0.303f, 0.816f);
                    //item.transform.rotation = Quaternion.Euler(1, 1, 1);
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
