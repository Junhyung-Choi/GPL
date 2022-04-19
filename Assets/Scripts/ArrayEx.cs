using System.Collections;
using UnityEngine;

public class ArrayEx : MonoBehaviour{
    public string [] sArray;

    private void Start() {
        sArray = new string[10];

        sArray[0]  = "These";
        sArray[1]  = "are";
        sArray[2]  = "some";
        sArray[3]  = "words";

        print("The length of sArray is: "+ sArray.Length);

        string str = "";
        foreach (string sTemp in sArray)
        {
            str += "|"+sTemp;
            if(sTemp == null) break;
        }
        print(str);
    }
}