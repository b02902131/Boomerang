using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MouseClickShoot : MonoBehaviour {

//	public Camera camera;
	public GameObject boomerang;
	private bool shootState = false;
	private Vector3 target = new Vector3();

	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);////(1)
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {////(2)
			if (Input.GetKeyDown(KeyCode.Q) && hit.transform.gameObject.tag == "floor") {
				shootState = true;////(3)
				target = new Vector3 (hit.point.x, this.transform.position.y, hit.point.z);

			}
		}
			
		////(7)
		if(shootState){////(5)
			shootState = false;
			if (Vector3.Distance (this.transform.position, target) < 0.1f) {
				

			} else {
				this.transform.LookAt (target);
				GameObject br = Instantiate (boomerang, this.transform.position + this.transform.forward, Quaternion.identity);
				Follower follower = br.GetComponent<Follower> ();
				follower.mouseClickMove = GetComponent<MouseClickMove> ();
				follower.Flyout (target);
				br.GetComponent<Follower> ().player = this.gameObject.transform;
			}
		}
	}
}