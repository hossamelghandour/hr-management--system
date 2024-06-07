namespace hr_system.DTOS
{
    public class PermissionDTO
    {
        public string Section { get; set; }
        public bool CanRead { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
    }
}
