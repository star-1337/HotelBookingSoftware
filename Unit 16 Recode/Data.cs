using System;
using System.Collections.Generic;
using System.Text;

namespace Unit_16_Recode
{
    class Data
    {
        private int room_no;
        private string name;
        private string address;
        private string phone_no;
        private string dob;
        
        public Data() // empty constructor 
        {
        }
        public Data(int _room_no, string _name, string _address, string _phone_no, string _dob)
        {
            room_no = _room_no;
            name = _name;
            address = _address;
            phone_no = _phone_no;
            dob = _dob;
        }

        public string[] ReturnData()
        {
            return new string[] { room_no.ToString(), name, address, phone_no, dob };
        }
    }
}
