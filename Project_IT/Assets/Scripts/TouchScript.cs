using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScript : MonoBehaviour
{
    public ParticleSystem blood;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           RaycastHit hit;

           Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Instantiate(blood, hit.point,Quaternion.identity);
                
            }
        }
    }
}
