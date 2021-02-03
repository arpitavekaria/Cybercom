using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
    public partial class PartialClass
    {
        public PartialClass(int _Id,string _FirstName,string _LastName)
        {
            this._Id = _Id;
            this._FirstName = _FirstName;
            this._LastName = _LastName;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Id = {0},FirstName = {1},LastName = {2}", _Id, _FirstName, _LastName);
        }
    }
}
