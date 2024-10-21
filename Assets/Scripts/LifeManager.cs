using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float invulnerableCounter = 10f;
    private bool invulnerable = false;

    public int livesNumber = 3;
    private static List<GameObject> stars = new List<GameObject>();


    void Start(){
        for (int i = 0; i < livesNumber; i++){
            Vector3 starPos = new Vector3(i, 0, 0);
            stars.Add(Instantiate(prefab, transform.position + starPos, transform.rotation));
            stars[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(invulnerable){
            if(invulnerableCounter > 10){
                invulnerableCounter -= Time.deltaTime;
                Debug.Log("Invulnérable !");
            }
            else{
                invulnerable = false;
                invulnerableCounter = 10f;
                
            }
        }
        
        for (int i = 0; i < stars.Count; i++){
            stars[i].SetActive(i < livesNumber);
        }
        Debug.Log(livesNumber);
    }

    void OnTriggerEnter(Collider other){
        int counter = livesNumber - 1;
        if(other.CompareTag("Enemy") && invulnerable == false){
            livesNumber--;
            invulnerable = true;
            other.gameObject.SetActive(false);
        }
    }

}
