using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyObjectPool : MonoBehaviour
{
    public static EasyObjectPool SharedInstance;
    [SerializeField]
    List<ObjectLibrary> objectLibraries;
    private Hashtable objects = new Hashtable();
    private Hashtable counterObjects= new Hashtable();
    private Hashtable counter= new Hashtable();
    private int[] idHelper;
    private void Awake() {
        SharedInstance = this;
    }
    private void Start() {
        idHelper = new int[objectLibraries.Count];
        for (int i = 0; i < objectLibraries.Count; i++)
        {
            int c = 0;
            idHelper[i] = objectLibraries[i].id;
            GameObject[] tmp = new GameObject[objectLibraries[i].totalObjects];
            int[] ctmp = new int[objectLibraries[i].totalObjects];
            for (int j = 0; j < objectLibraries[i].totalObjects; j++)
            {
                tmp[j] = Instantiate(objectLibraries[i].objectPrefab);
                ctmp[j] = c;
                c = c+1;
            }
            objects.Add(objectLibraries[i].id,tmp);
            counterObjects.Add(objectLibraries[i].id,ctmp);
            counter.Add(objectLibraries[i].id,0);
        }
    }
    public GameObject GetPooledObject(int id){
        int[] ctmp = (int[])counterObjects[id];
        if((int)counter[id] == ctmp.Length-1){
            resetCounter(id);
        }
        counter[id] = (int)counter[id]+1;
        GameObject[] tmp = (GameObject[])objects[id];
        return tmp[(int)counter[id]];
    }
    private void resetCounter(int id){
        counter[id] = 0;
        GameObject[] tmp = (GameObject[])objects[id];
        int[] ltmp = (int[])counterObjects[id];
        for (int i = 0; i < tmp.Length; i++)
        {
            if(!tmp[i].activeInHierarchy){
                ltmp[i] = i;
            }
        }
        counterObjects[id] =ltmp;
    }
    public void disableObjects(int id){
        counter[id] =0;
        GameObject[] otmp = (GameObject[])objects[id];
        int[] ltmp = (int[])counterObjects[id];
        for (int i = 0; i < otmp.Length; i++)
        {
            if(otmp[i].activeInHierarchy){
                otmp[i].SetActive(false);
            }
        }
        objects[id] = otmp;
        for (int i = 0; i < otmp.Length; i++)
        {
            if(!otmp[i].activeInHierarchy){
                ltmp[i] = i;
            }
        }
        counterObjects[id] = ltmp;
    }
    public void disableAllObjects(){
        for (int id = 0; id < idHelper.Length; id++)
        {
            GameObject[] otmp = (GameObject[])objects[idHelper[id]];
            int[] ctmp = (int[])counterObjects[idHelper[id]];
            counter[id] =0;
            for (int i = 0; i < otmp.Length; i++)
            {
                if(otmp[i].activeInHierarchy){
                    otmp[i].SetActive(false);
                }
            }
            objects[idHelper[id]] = otmp;
            for (int i = 0; i < otmp.Length; i++)
            {
                if(!otmp[i].activeInHierarchy){
                    ctmp[i] = i;
                }
            }
            counterObjects[idHelper[id]] = ctmp;
        }
    }
}
[System.Serializable]
public class ObjectLibrary
{
    public int id;
    public string objectName;
    public GameObject objectPrefab;
    public int totalObjects;
}

