using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MouseClickShoot : PlayerShoot {

//	public Camera camera;

	private bool shootState = false;
	private Vector3 target = new Vector3();
	public BloodMgr bloodMgr;
	public ScoreUIMgr scoreUIMgr;
	public float fowardDistance = 1;
	int mask;

	void Start(){
		mask = LayerMask.GetMask ("Plane");
		bloodMgr = GameObject.Find ("BloodMgr").GetComponent<BloodMgr>();
		scoreUIMgr = GameObject.Find ("ScoreUI").GetComponent<ScoreUIMgr> ();
	}

	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);////(1)
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 1000, mask)) {////(2)
			if (Input.GetMouseButtonDown(0) && hit.transform.gameObject.tag == "floor") {
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
				target = this.transform.position + this.transform.forward * 10;
				//			this.transform.LookAt (target);
				GameObject br = Instantiate (boomerang, this.transform.position + this.transform.forward*fowardDistance, Quaternion.identity);
				Follower follower = br.GetComponent<Follower> ();
				follower.mouseClickMove = GetComponent<MouseClickMove> ();
				follower.wasdMove = GetComponent<WASDMove> ();
				follower.Flyout (target);
				follower.player = this.gameObject.transform;
				Bonerang bonerang = br.GetComponent<Bonerang> ();
				bonerang.scoreUIMgr = scoreUIMgr;
				bloodMgr.bloodLoss (1);

				//finish shoot
				finishShoot();

			}
		}
	}

	//for prototype
	public bool isFinishShoot = false;
	void finishShoot(){
		isFinishShoot = true;
	}
}