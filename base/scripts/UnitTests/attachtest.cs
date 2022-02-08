// built-in function extending, min returns the smallest arg passed to it
$min2 = "nothing";
function min2_before() before min { %argv1 = 100000; }
function min2_after() after min { $min2 = "after"; }

assert( "min(0,1,2)", "1" );
assert( "$min2", "after" );

// explicit attaches
function min2_naked_before() { %argv1 = -10000; }
function min2_naked_after() { $min2 = "naked"; }

min2_naked_before.attach(min, before);
min2_naked_after.attach(min, after);

assert( "min(0,1,2)", "-10000" );
assert( "$min2", "naked" );

// detach
$min2 = "nothing";
min2_after.detach(); min(0,1,2);
assert( "$min2", "naked" );

$min2 = "nothing";
min2_naked_after.detach(); min(0,1,2);
assert( "$min2", "nothing" );

// halting
function min2_halt_min() before min { halt "min2halt"; }
assert( "min(0,1,2)", "min2halt" );
min2_halt_min.detach();

min2_before.detach();
min2_naked_before.detach();

// non-built in extending
function main( %a, %b ) { return ( %a > %b ) ? %a : %b; }
assert( "main(1, 2)", "2" );

function pre( %a, %b ) before main { %a = 50; %bogus = "bogus"; }
assert( "main(1, 2)", "50" );

// return variable modifying
function post( %a, %b ) after main { %bogus = "bogus"; return_chained %ret * 150; }
function post2( %a, %b ) after main { %bogus = "bogus"; return_chained %ret * 2; }
assert( "main(1, 2)", "15000" );

function pre( %a, %b ) before main { halt "prehalt"; %bogus = "bogus"; }
assert( "main(1, 2)", "prehalt" );
pre.detach();
post.detach();
post2.detach();

 // attaching pre2 will cause an error and it won't get attached
function pre2() { halt; }
function pre3( %a, %b ) { %a = 150; }
pre3.attach(main, before);
pre2.attach(main, before);
assert( "main(1, 2)", "150" );

// test extension restriction
$a = 0;
function pre() before noextend { $a = 50; }
noextend();
assert( "$a", "0" );

function post() after noextend { $a = 100; }
noextend();
assert( "$a", "0" );
