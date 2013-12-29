#pragma strict

public var orgPos : float;
var offset : int;
var FollowCamera : boolean;

function Start () {
	orgPos = Camera.main.transform.position.x;
}

function Update () {
	if (FollowCamera){ 
			transform.position.x = (Camera.main.transform.position.x - orgPos)/offset;
		}
	else{
			transform.position.x = (orgPos - Camera.main.transform.position.x)/offset;
		}

}