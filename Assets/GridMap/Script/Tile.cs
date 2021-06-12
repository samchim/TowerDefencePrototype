using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public float width = 1, height =1;
    [SerializeField] private bool onHover = false;
    [SerializeField] private GameObject highlight;
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        highlight.SetActive(onHover);
    }

    void OnMouseEnter(){
        onHover = true;
    }

    void OnMouseExit(){
        onHover = false;
    }
}
