using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvldDataAccessLayer;
using DvldDataAccessLayer.DALCalsses;

namespace DvldBusinessLayer.BLLClasses
{
    public class clsTestType
    {
        public int TestTypeID { get; set; }
        public decimal Fees { get; set; }
        public decimal RetakeFees { get; set; }

        // جلب رسوم الفحص الأساسي
        public static decimal GetFeesByTestTypeID(int testTypeID)
        {
            return TestTypeDB.GetFeesByTestTypeID(testTypeID);
        }

        // جلب رسوم إعادة الفحص
        public static decimal GetRetakeFeesByTestTypeID(int testTypeID)
        {
            return TestTypeDB.GetRetakeFeesByTestTypeID(testTypeID);
        }


    }
}
