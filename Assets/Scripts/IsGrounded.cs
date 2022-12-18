using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    [SerializeField] GameObject player;

    private void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Untagged")
        {
            player.GetComponent<PlayerMove>().isGrounded = true;
        }
        if (collider.tag == "plate")
        {
            Destroy(collider.gameObject);
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Untagged")
        {
            player.GetComponent<PlayerMove>().isGrounded = false;
        }
    }
}