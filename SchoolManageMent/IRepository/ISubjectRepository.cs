using SchoolManageMent.Models;

namespace SchoolManageMent.IRepository
{
    public interface ISubjectRepository
    {
        bool SaveSubject(List<Subject> subjects);
    }
}
