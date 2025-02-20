using ExaminantionSystem_R3.Models;
using ExaminantionSystem_R3.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace ExaminantionSystem_R3.Repositories
{
    public class QuestionRepository : GeneralRepository<Question>
    {
        public Question GetByIdWithInclude(int id)
        {
            return _dbSet.Where(x => x.ID == id).Include(x => x.Choices).FirstOrDefault();
        }
        public IQueryable<Question> GetByLevel(QuestionLevel questionLevel, int HowManyQuestions)
        {
            IQueryable<Question> questions = _dbSet.Where(x => x.Level == questionLevel).OrderBy(x=> Guid.NewGuid()).Take(HowManyQuestions);
            return questions;
        }
    }
}
