using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstNodeChoice : MonoBehaviour {
    int childNum;
    int targetIndex;
    float ringRadius = 3.0f;

	void Start() {
        childNum = transform.childCount;
        targetIndex = 0;
        placeNodes();
    }

    void placeNodes() {
        for(int i = 0; i < childNum; i++) {

        }
    }
        

    void turnLeft() {

    }
    void turnRight() {

    }

}
