using Unity.VisualScripting;
using UnityEngine;

public class CallPause : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            gameObject.SetActive(true);
        }
    }
}
