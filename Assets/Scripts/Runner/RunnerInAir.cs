using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Magicolo;

public class RunnerInAir : State {
	
	Runner Layer {
		get { return ((Runner)layer); }
	}
	
	public override void OnUpdate() {
		RaycastHit2D hitLeft = Physics2D.Raycast(transform.position - transform.right, -transform.up, 2, new LayerMask().AddToMask("Runner").Inverse());
		RaycastHit2D hitCenter = Physics2D.Raycast(transform.position, -transform.up, 2, new LayerMask().AddToMask("Runner").Inverse());
		RaycastHit2D hitRight = Physics2D.Raycast(transform.position + transform.right, -transform.up, 2, new LayerMask().AddToMask("Runner").Inverse());
		
		if (Layer.debug) {
			Debug.DrawRay(transform.position - transform.right, -transform.up * 2, Color.green);
			Debug.DrawRay(transform.position, -transform.up * 2, Color.cyan);
			Debug.DrawRay(transform.position + transform.right, -transform.up * 2, Color.green);
		}
		
		if (hitLeft.collider != null || hitCenter.collider != null || hitRight.collider != null) {
			SwitchState<RunnerGrounded>(1);
			return;
		}
	}
}
