using UnityEngine;
using System.Collections;

public class BGScaler : MonoBehaviour {
	
	void Start () {
		var height = Camera.main.orthographicSize * 2f; //calculating Screen height so it can render for any size
		var widht = height * Screen.width / Screen.height; //calculating Screen width so it can render for any size

		if (gameObject.name == "Background"){ 
			transform.localScale = new Vector3 (widht, height, 0);
		} else {
			transform.localScale = new Vector3 (widht + 3f, 5, 0);
		}

	}

}
