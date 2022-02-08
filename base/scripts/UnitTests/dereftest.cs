$testvar = "$testvar2";
$testvar2 = "$result1";
$testfun = "String::trim";

**$testvar = " double deref ";
*$testvar = " deref ";

$testvar3 = "$testvar4";
$testvar4 = "$testvar5";
*(*(*"$testvar3")) = "triple nested stratom deref";

$abc = "$xyz";
$xyz = *$testvar3;

assert( "$result1", " double deref " );
assert( "$testvar2", " deref " );
assert( "$testvar5", "triple nested stratom deref" );
assert( "*$abc", "$testvar5" );
assert( "*$testfun( $result1 )", "double deref" );
assert( "*$testfun( $testvar2 )", "deref" );