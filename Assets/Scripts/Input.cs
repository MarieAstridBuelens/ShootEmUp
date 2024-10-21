using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{
    [SerializeField] InputActionAsset inputActions;
    [SerializeField] private float speed = 1f;
    InputAction move;
    [SerializeField] Camera cameraOutput;
    
    void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable();
        move = inputActions["Move"];//utilisé comme un dictionnaire, donc crochets droits

    }
    void OnDisable()
    {
        inputActions.FindActionMap("Player").Disable();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenpos = cameraOutput.WorldToScreenPoint(transform.position);
        Vector3 moveAmount = move.ReadValue<Vector3>();
        Debug.Log(moveAmount);
        if(screenpos.x < cameraOutput.pixelWidth){
            transform.position += new Vector3(moveAmount.x, 0, 0) * Time.deltaTime * speed;
        } else transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * speed;

        if(screenpos.x >= 0){
            transform.position += new Vector3(moveAmount.x, 0, 0) * Time.deltaTime * speed;
        } else transform.position += new Vector3(1, 0, 0) * Time.deltaTime * speed;

        if(screenpos.y < cameraOutput.pixelHeight){
            transform.position += new Vector3(0, moveAmount.y, 0) * Time.deltaTime * speed;
        } else transform.position += new Vector3(0, -1, 0) * Time.deltaTime * speed;

        if(screenpos.y >= 0){
            transform.position += new Vector3(0, moveAmount.y, 0) * Time.deltaTime * speed;
        } else transform.position += new Vector3(0, 1, 0) * Time.deltaTime * speed;
        
    }
}
