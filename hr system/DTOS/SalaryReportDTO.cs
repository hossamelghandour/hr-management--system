namespace hr_system.DTOS
{
    public class SalaryReportDTO
    {
        public string EmployeeName { get; set; }
        public string DepartmetName { get; set; }
        public double Salary { get; set; }
        public int Attend { get; set; }
        public int Absent { get; set; }
        public int Additional_hours { get; set; }
        public int Discount_hours { get; set; }

        public double TotalAditionalHours { get; set; }
        public double TotalDiscountHours { get; set; }

        public double TotalNetSalary { get; set; }
    }
}
