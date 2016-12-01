using UnityEngine;
using System.Collections;

public class CreateBuildingAction : ActionBehavior {

	public GameObject BuildingPrefab;
	public float MaxBuildDistance = 50;

	public GameObject GhostBuildingPrefab;
	private GameObject active = null;

	public override System.Action GetClickAction ()
	{
		return delegate() {
			var go = GameObject.Instantiate(GhostBuildingPrefab);
			var finder = go.AddComponent<FindBuildingSite>();
			finder.BuildingPrefab = BuildingPrefab;
			finder.MaxBuildDistance = MaxBuildDistance;
			finder.Info = GetComponent<Player> ().Info;
			finder.Source = transform;
			active = go;
		};
	}

	void Update() {
		if (active == null)
			return;
		if (Input.GetKeyDown (KeyCode.Escape))
			GameObject.Destroy (active);
	}

	void onDestroy() {
		if (active == null)
			return;
		Destroy (active);
	}
}
