using UnityEngine;
using System.Collections;

public static class Collisions {

	/// <summary>
	/// Used to ignore collisions between a collider, and all of the colliders in a named hierarchy
	/// </summary>
	/// <param name="collider">Collisions of this object with specified groupName will be ignored</param>
	/// <param name="groupName"> The name of the root object in a GameObject hierarchy. </param>
	/// <param name="ignore">If set to <c>true</c> ignore collisions between collider, and all colliders in named group</param>
	public static void IgnoreCollisionWithGroup(Collider collider, string groupName, bool ignore) {
		Collider[] colliders = GameObject.Find (groupName).GetComponentsInChildren<Collider>();
		
		foreach (Collider groupCollider in colliders) {
			if(groupCollider.enabled) {
				Physics.IgnoreCollision (collider, groupCollider, ignore);
			}
		}
	}

}
