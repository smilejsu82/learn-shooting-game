using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 currentPos = this.transform.position;
        Vector3 nextPos = new Vector3(h, v, 0).normalized * this.speed * Time.deltaTime;
        this.transform.position = currentPos + nextPos;
    }
}
