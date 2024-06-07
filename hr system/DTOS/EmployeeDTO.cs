namespace hr_system.DTOS
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
        public string NationalId { get; set; }
        public DateTime HireDate { get; set; }
        public double Salary { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public TimeSpan LeaveTime { get; set; }
        public string UserId { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
