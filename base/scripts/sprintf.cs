// sprintf takes a max of 9 arguments!
function echof( %fmt, %a1, %a2, %a3, %a4, %a5, %a6, %a7 ) {
	return echo(sprintf( %fmt, %a1, %a2, %a3, %a4, %a5, %a6, %a7 ));
}

function errorf( %fmt, %a1, %a2, %a3, %a4, %a5, %a6, %a7 ) {
	return error(sprintf( %fmt, %a1, %a2, %a3, %a4, %a5, %a6, %a7 ));
}

function echocf( %color, %fmt, %a1, %a2, %a3, %a4, %a5, %a6, %a7 ) {
	return echoc(%color, sprintf( %fmt, %a1, %a2, %a3, %a4, %a5, %a6, %a7 ));
}


function evalf( %fmt, %a1, %a2, %a3, %a4, %a5, %a6, %a7 ) {
	return eval(sprintf( %fmt, %a1, %a2, %a3, %a4, %a5, %a6, %a7 ));
}

function execf( %fmt, %a1, %a2, %a3, %a4, %a5, %a6, %a7 ) {
	return exec(sprintf( %fmt, %a1, %a2, %a3, %a4, %a5, %a6, %a7 ));
}
