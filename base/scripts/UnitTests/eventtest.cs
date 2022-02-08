Event::Clear( eventTest );

function eventinc() { $a++; }
function eventdec() { $a--; }

// test multiple attaches
$a = 0;
Event::Attach( eventTest, eventinc );
Event::Attach( eventTest, Eventinc );
Event::Attach( eventTest, eventInc );
Event::Attach( eventTest, eventinC );
Event::Trigger( eventTest );

assert( "$a", "1" );

// more multiple attaches
$a = 10;
Event::Attach( eventTest, eventdec );
Event::Attach( eventTest, Eventdec );
Event::Trigger( eventTest );

assert( "$a", "10" );

// make sure it gets detached if needed
$a = 100;
Event::Detach( eventTest, eventinc );
Event::Trigger( eventTest );

assert( "$a", "99" );