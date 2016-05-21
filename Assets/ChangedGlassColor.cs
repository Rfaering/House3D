using UnityEngine;
using System.Collections;

public class ChangedGlassColor : MonoBehaviour {

	public void ChangeGlassColor(Color color)
    {
        GetComponent<Renderer>().materials[1].color = color;
    }
}
