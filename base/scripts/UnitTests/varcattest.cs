$dollar = "$";
$test["hi"] = "var_aidx";
$test = "abc";
$test2 = "xyz";
$abcxyz = "variable";
$test3 = $test["hi"]~$dollar~" stratom "~$abcxyz~(5);
*$dollar~$test["hi"] = "string concat + deref";
*$dollar~$test["hi"]~( ( 3 > 2 ) ? 2 : 100 ) = "string concat(with expr) + deref";
*$dollar~( ( 3 > 2 ) ? "abc" : "def" ) = "string concat(with expr) + deref2";
$var_aidx2 = "string concat(with expr) + deref";

assert( "$test~$test2~\"!\"~(5)", "abcxyz!5" );
assert( "*$dollar~\"abc\"~$test2", "variable" );
assert( "*$dollar~$test~$test2", "variable" );
assert( "*($dollar~$test~$test2)", "variable" );
assert( "$test3", "var_aidx$ stratom variable5" );
assert( "$var_aidx", "string concat + deref" );
assert( "$var_aidx2", "string concat(with expr) + deref" );
assert( "$abc", "string concat(with expr) + deref2" );
assert( "~0", "-1" );
assert( "~0 + ~0", "-2" );

