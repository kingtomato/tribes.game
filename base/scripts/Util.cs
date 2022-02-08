function clamp( %a, %min, %max ) {
	return min( max( %a + 0, %min ), %max );
}