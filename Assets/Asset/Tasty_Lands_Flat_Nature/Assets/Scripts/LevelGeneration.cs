using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour {

public GameObject[] objects;

void Start() {

int rand = Random.Range(0, objects.Length);
if(objects[rand] == null) 
{
	//Debug.Log("pas cool '" + gameObject.name + "' " + rand + "/" + objects.Length);
}
var created = Instantiate(objects[rand], transform.position, Quaternion.identity);
created.transform.SetParent(this.transform);

}

}
