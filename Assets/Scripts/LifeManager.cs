using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    public int livesNumber = 3;
    private static List<GameObject> stars = new List<GameObject>();

    void Awake(){
        for (int i = 0; i < livesNumber; i++){
            stars.Add(prefab);
        }
    }

    void Start(){
        for (int i = 0; i < livesNumber; i++){
            Vector3 starPos = new Vector3(i, 0, 0);
            Instantiate(stars[i], transform.position + starPos, transform.rotation);
            stars[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(livesNumber);
    }

    void OnTriggerEnter(Collider other){
        int counter = livesNumber - 1;
        if(other.CompareTag("Enemy")){
            livesNumber--;
            counter--;
            if(counter >= 0){
                stars[counter].SetActive(false);
            }
        }
    }

}
