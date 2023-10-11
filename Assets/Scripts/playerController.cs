using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody rb;
    public float kekuatanLompatan = 300f;
    public float kecepatanGerakan;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, kekuatanLompatan, 0));
        }

        rb.velocity = new Vector3(kecepatanGerakan * Time.deltaTime, rb.velocity.y, rb.velocity.z);
    }

    private void OnTriggerEnter(Collider c) 
    {
        if(c.gameObject.GetComponent<obstacleController>() != null)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
