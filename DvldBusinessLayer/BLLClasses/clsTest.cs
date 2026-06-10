using DvldDataAccessLayer.DALCalsses;

namespace DvldBusinessLayer.BLLClasses
{
    public class clsTest
    {
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public bool Save()
        {
            return TestDB.AddNewTest(
                TestAppointmentID,
                TestResult,
                Notes,
                CreatedByUserID
            );
        }
    }
}
