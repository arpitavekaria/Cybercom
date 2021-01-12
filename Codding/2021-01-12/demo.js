var name = 'john';
//declaring first function
function first()
{
	var a = 'hello';
// calling second function 
	second();
	var x = a + name;
	console.log(x);
}
function second()
{
	var b = 'hi';
//calling third function	
	third();
	var y = b + name;
	console.log(y);
}
function third()
{
	var c = 'hey';
	var z = c + name;
	console.log(z);
}
first();
//it will return o/p like: 'heyhihello'