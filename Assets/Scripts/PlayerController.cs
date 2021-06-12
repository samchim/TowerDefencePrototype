using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    public float speed = 5f;
    public float turnspeed = 10f;
    public Transform movePoint;
    public Transform selectPoint;

    public int gridXLength = 15;
    public int gridYLength = 8;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        selectPoint.parent = null;
        selectPoint.position = new Vector3(1f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);   

        // Player Movement
        if (Vector3.Distance(transform.position, movePoint.position) <= 0f) {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f) {
                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                // Detect x axis out of bounds 
                if (movePoint.position.x < 0 || movePoint.position.x > gridXLength) {
                    movePoint.position -= new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
                selectPoint.position = movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);

            } else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) {
                movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                // Detect y axis out of bounds 
                if (movePoint.position.y < 0 || movePoint.position.y > gridYLength) {
                    movePoint.position -= new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
                selectPoint.position = movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);  
            
            } else if (Input.GetKeyDown(KeyCode.Q)) {
                if (selectPoint.position.y > movePoint.position.y) {
                    selectPoint.position = movePoint.position + new Vector3(-1f, 0f, 0f);
                } else if (selectPoint.position.x < movePoint.position.x) {
                    selectPoint.position = movePoint.position + new Vector3(0f, -1f, 0f);
                } else if (selectPoint.position.y < movePoint.position.y) {
                    selectPoint.position = movePoint.position + new Vector3(1f, 0f, 0f);
                } else if (selectPoint.position.x > movePoint.position.x) {
                    selectPoint.position = movePoint.position + new Vector3(0f, 1f, 0f);
                } 

            } else if (Input.GetKeyDown(KeyCode.E)) {
                if (selectPoint.position.y > movePoint.position.y) {
                    selectPoint.position = movePoint.position + new Vector3(1f, 0f, 0f);
                } else if (selectPoint.position.x > movePoint.position.x) {
                    selectPoint.position = movePoint.position + new Vector3(0f, -1f, 0f);
                } else if (selectPoint.position.y < movePoint.position.y) {
                    selectPoint.position = movePoint.position + new Vector3(-1f, 0f, 0f);
                } else if (selectPoint.position.x < movePoint.position.x) {
                    selectPoint.position = movePoint.position + new Vector3(0f, 1f, 0f);
                }
            } 
        }
    }
}
