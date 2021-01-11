/*coding challenge 2 */
// first check average of two match 
var johnTeamAvg = (89 + 120 + 103)/3;
var mikeTeamAvg = (116 + 94 + 123)/3;

console.log("John's and Mike's match");

// check winning team
if(johnTeamAvg > mikeTeamAvg)
	{console.log("John Team Wins: " + johnTeamAvg);}
else
	{console.log("Mike Team Wins: " + mikeTeamAvg);}

// now adding merry's average
console.log("\nNow adding Merry Team and checking");
var merryTeamAvg = (97 + 134 + 105)/3;

// checking winning team from these three team using switch case
switch(true){
	case johnTeamAvg > mikeTeamAvg && johnTeamAvg > merryTeamAvg:
		console.log("John's Team Wins");
		break;

	case mikeTeamAvg > johnTeamAvg &&  mikeTeamAvg > merryTeamAvg:
		console.log("Mike Team Wins");
		break;

	case merryTeamAvg > johnTeamAvg && merryTeamAvg > mikeTeamAvg:
		console.log("Merry Team Wins");
		break;

	case johnTeamAvg == mikeTeamAvg && johnTeamAvg > merryTeamAvg:
		console.log("John's and Mike's Team are winning");
		break;

	case johnTeamAvg == merryTeamAvg && johnTeamAvg > mikeTeamAvg:
		console.log("John's and Merry's are winning");
		break;

	case mikeTeamAvg == merryTeamAvg && mikeTeamAvg > johnTeamAvg:
		console.log("Mike's and Merry's are winning");
		break;

	default:
		console.log("They all three teams are winning"); 
}

console.log("\nScore entered by User");

//if score changed by user
var johnMatch1 = prompt("Enter John match 1 score: ");
var johnMatch2 = prompt("Enter John match 2 score: ");
var johnMatch3 = prompt("Enter John match 3 score: ");

var mikeMatch1 = prompt("Enter Mike match 1 score: ");
var mikeMatch2 = prompt("Enter Mike match 2 score: ");
var mikeMatch3 = prompt("Enter Mike match 3 score: ");


var merryMatch1 = prompt("Enter Merry match 1 score: ");
var merryMatch2 = prompt("Enter Merry match 2 score: ");
var merryMatch3 = prompt("Enter Merry match 3 score: ");

johnTeamAvg = (johnMatch1 + johnMatch2 + johnMatch3)/3;
mikeTeamAvg = (mikeMatch1 + mikeMatch2 + mikeMatch3)/3;
merryTeamAvg = (merryMatch1 + merryMatch2 + merryMatch3)/3;

switch(true){
	case johnTeamAvg > mikeTeamAvg && johnTeamAvg > merryTeamAvg:
		console.log("John's Team Wins");
		break;

	case mikeTeamAvg > johnTeamAvg &&  mikeTeamAvg > merryTeamAvg:
		console.log("Mike Team Wins");
		break;

	case merryTeamAvg > johnTeamAvg && merryTeamAvg > mikeTeamAvg:
		console.log("Merry Team Wins");
		break;

	case johnTeamAvg == mikeTeamAvg && johnTeamAvg > merryTeamAvg:
		console.log("John's and Mike's Team are winning");
		break;

	case johnTeamAvg == merryTeamAvg && johnTeamAvg > mikeTeamAvg:
		console.log("John's and Merry's are winning");
		break;

	case mikeTeamAvg == merryTeamAvg && mikeTeamAvg > johnTeamAvg:
		console.log("Mike's and Merry's are winning");
		break;

	default:
		console.log("They all three teams are winning");
}