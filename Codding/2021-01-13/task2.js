//initialize mark object and assigning values to it
var mark = {
  name: 'Mark Cage',
  mass: '70',
  height: '1.65',
  //function expression or method
  calcBMI: function(){
    this.bmi = this.mass / Math.pow(this.height,2);
  }
}
 
//method call
mark.calcBMI();
console.log(mark);

//initialize john object and assigning values to it
var john = {
  name: 'John Smith',
  mass: '85',
  height: '1.75',
  //function expression or method
  calcBMI: function(){
    this.bmi = this.mass / Math.pow(this.height,2);
  }
}

//method call
john.calcBMI();
console.log(john);

//Checking who's BMI is higher and print its name and BMI
if(mark.bmi > john.bmi)
{
  console.log(mark.name + ' has a higher BMI' + '=' + mark.bmi);
}
else  if (mark.bmi < john.bmi)
{
  console.log(john.name + ' has a higher BMI'  + '=' + john.bmi);
} 
else 
{
  console.log(mark.name + ' and ' + john.name + ' has the same BMI' + '=' + mark.bmi);
}