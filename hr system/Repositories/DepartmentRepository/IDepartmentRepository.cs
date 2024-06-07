using hr_system.Models;

namespace hr_system.Repositories.DepartmentRepository
{
    public interface IDepartmentRepository
    {
        List<Department>GetAll();
        Department GetById(int id);
        void Add(Department department);
        void Update(Department department);
        void Delete(Department department); 
    }
}
