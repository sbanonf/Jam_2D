using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class CamZone : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera virtualCamera = null;
    // Start is called before the first frame update
    void Start()
    {
        virtualCamera.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            virtualCamera.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            virtualCamera.enabled = false;
        
        }
    }
}
