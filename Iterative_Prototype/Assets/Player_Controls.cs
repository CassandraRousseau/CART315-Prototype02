using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controls : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;
    private bool jumpKeyPressed;
    public float runSpeed = 10f;
    float horizontalInput = 0f;
    public Rigidbody rigidbodyComponent;
    
    // Start is called before the first frame update

   
    void Start()
    {

        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space)) {
            jumpKeyPressed = true;
        }
        horizontalInput = Input.GetAxis("Horizontal") * runSpeed;
    }
    private void FixedUpdate()
    {
    /*    rigidbodyComponent.Move(horizontalInput * Time.fixedDeltaTime, false, false);*/
        rigidbodyComponent.velocity = new Vector3(horizontalInput * Time.fixedDeltaTime, GetComponent<Rigidbody>().velocity.y, 0);

        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }
        if (jumpKeyPressed)
        {

            float jumpPower = 7f;

            rigidbodyComponent.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            jumpKeyPressed = false;
        }

        if (rigidbodyComponent.position.y < 0.1f)
        {
            Debug.Log("rigidbodyComponent.position.y");
            FindObjectOfType<GameSettings>().EndGame();
        }
    }


}
