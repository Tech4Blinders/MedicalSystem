using MedicalSystem.CoreLayer;

namespace MedicalSystem.DataAccessLayer;


public class DoctorQualificationRepo : GenericRepo<Doctor>, IDoctorQualificationRepo
{
    public DoctorQualificationRepo(ApplicationDbContext context) : base(context) { }

    public  Task<Doctor>? AddAsync(Doctor entity)
    {
        throw new NotImplementedException();
    }

    public  Task<IEnumerable<Doctor>?> AddRange(IEnumerable<Doctor> entities)
    {
        throw new NotImplementedException();
    }

    public Task<int> CountAsyncWhere(System.Linq.Expressions.Expression<Func<Doctor, bool>> Filter)
    {
        throw new NotImplementedException();
    }

    public void Delete(Doctor entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Doctor>?> GetWith(System.Linq.Expressions.Expression<Func<Doctor, bool>>? Filter = null, string[]? Includes = null)
    {
        throw new NotImplementedException();
    }

    public Doctor? Update(Doctor entity)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<Doctor>?> IGenericRepo<Doctor>.GetAllAsyn()
    {
        throw new NotImplementedException();
    }

    Task<Doctor?> IGenericRepo<Doctor>.GetByIdAsyn(int id)
    {
        throw new NotImplementedException();
    }
}
