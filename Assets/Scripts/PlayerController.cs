using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 3.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        transform.Translate(x, 0, z);
        
        var y = Input.GetAxis("Mouse X") * Time.deltaTime * 50.0f;
        transform.Rotate(0, y, 0);
    }
}