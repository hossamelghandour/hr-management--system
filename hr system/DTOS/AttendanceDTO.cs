namespace hr_system.DTOS
{
    public class AttendanceDTO
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public TimeSpan? LeaveTime { get; set; }
        public int employeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? DepartmentName { get; set; }
    }
}
