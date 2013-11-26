#pragma strict

function Update () {

if(transform.position.y < -5){
transform.position.y = 0;
transform.position.x = 0;
transform.position.z = 0;

rigidbody.velocity = Vector3.zero;

}

}