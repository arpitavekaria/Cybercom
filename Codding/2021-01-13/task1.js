//initialize array
var billsBeforeTip = [124, 48, 268]; 
var tipAmounts = []; 
var finalAmounts = []; 

//Here it is function declaration for count tip amount
function tipCalculator(amount)
{
      var percentage;
      if (amount <= 50) 
      {
          percentage = 0.2;  
      }
      else if (50 < amount <= 200)
      {
          percentage = 0.15;
      }
      else 
      {
          percentage = 0.1;
      }
    return percentage *  amount;
  }

//Here is is passing the bill amount to the function and couting total amount
for (i = 0; i< billsBeforeTip.length; i++)
{
  tipAmounts[i] = tipCalculator(billsBeforeTip[i]);
  finalAmounts[i] = billsBeforeTip[i] + tipAmounts[i];
  console.log([i] + '. Total tip: ' + tipAmounts[i]);
}

//Print amount value befor tip and after tip
console.log('\nBills before tips: ' + billsBeforeTip);
console.log('Final Amounts: ' + finalAmounts);