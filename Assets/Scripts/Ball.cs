using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int id;
    [SerializeField]
    MeshRenderer meshRenderer;

    public void PainColor()
    {
        switch (id)
        {
            case 0:
                meshRenderer.material.color = Color.red;
                break;
            case 1:
                meshRenderer.material.color = Color.green;
                break;
            case 2:
                meshRenderer.material.color = Color.blue;
                break;
        }
    }

}
