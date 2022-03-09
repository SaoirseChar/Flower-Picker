using UnityEngine;

public class AutoRotation : MonoBehaviour
{
    private float y;
    public float speed;

    private void Update()
    {
        y += Time.deltaTime * speed;
        transform.rotation = Quaternion.Euler(0, y, 0);
    }
}
