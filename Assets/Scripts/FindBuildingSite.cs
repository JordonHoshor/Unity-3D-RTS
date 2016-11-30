using UnityEngine;
using System.Collections;

public class FindBuildingSite : MonoBehaviour {

	Renderer rend;
	Color Red = new Color(1, 0, 0, 0.5f);
	Color Green = new Color(0, 1, 0, 0.5f);

	void Start(){
		rend = GetComponent<Renderer> ();
	}

	// Update is called once per frame
	void Update () {
		var tempTarget = RtsManager.Current.ScreenPointToMapPosition (Input.mousePosition);
		if (tempTarget.HasValue == false)
			return;

		transform.position = tempTarget.Value;
		if (RtsManager.Current.IsGameObjectSafeToPlace (gameObject)) {
			rend.material.color = Green;
		} else {
			rend.material.color = Red;
		}
	}
}
