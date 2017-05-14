using UnityEngine;
using System.Collections;

public class MouseClickMove : MonoBehaviour {

	private bool moveState = false;
	public Vector3 target = new Vector3();
	public float speed = 1;
	private Vector3 input01;
	public int InputMouseButton;
	private Rigidbody rigidbody;
	int mask;

	void Start(){
		mask = LayerMask.GetMask ("Plane");
		rigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);////(1)
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 1000, mask)) {////(2)
			if (Input.GetMouseButtonDown (InputMouseButton) && hit.transform.gameObject.tag == "floor") {
				moveState = true;////(3)
				target = new Vector3 (hit.point.x, this.transform.position.y, hit.point.z);
			}
		}
		float step = speed * Time.deltaTime;////(4)
		////(7)
		if (moveState) {////(5)
			if (Vector3.Distance (this.transform.position, target) < 0.1f) {
				moveState = false;
				rigidbody.velocity = Vector3.zero;
			} else {
				this.transform.LookAt (target);
				//			this.transform.position = Vector3.MoveTowards (this.transform.position, target, step);////(6)
				rigidbody.velocity = (target - this.transform.position).normalized * speed;
			}
		}
	}
}