namespace Roomie.Entity
{
    public class Vaccancy
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public string Experience { get; set; }
        public string Description { get; set; }
        public string SalaryOffered { get; set; }

        public bool isValid { get; set; }
        public int DepartmentId { get; set; }

        public Department ForDepartment { get; set; }


    }
}
