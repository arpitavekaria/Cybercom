/* coding challenge 1 */
//variable declaration
var markMass; var markHeight; 
var johnMass; var johnHeight; 
var markBMI; var johnBMI;

//prompt is used for pop up box and entering the value
markMass = prompt("What is Mark's Mass?");
markHeight = prompt("What is Mark's Height?");

johnMass = prompt("What is John's Mass?");
johnHeight = prompt("What is John's Height?");

//calculating BMI
markBMI = markMass / (markHeight * markHeight);
johnBMI = johnMass / (johnHeight * johnHeight);

//checking bigger BMI
var checkBMI   = markBMI > johnBMI;

console.log("Is mark's BMI higher than john's?" + ' ' + checkBMI);