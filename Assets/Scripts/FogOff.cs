using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogOff : MonoBehaviour
{
    private bool revertFogState = false;
    void OnPreRender()
    {
        revertFogState = RenderSettings.fog;
        RenderSettings.fog = enabled;
    }
    void OnPostRender()
    {
        RenderSettings.fog = revertFogState;
    }
}
