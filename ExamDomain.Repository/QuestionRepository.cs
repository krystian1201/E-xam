using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ExamDomain.Model;

namespace ExamDomain.Repository
{
    //public class QuestionRepository : IDisposable where T: class 
    //{
        //private readonly DbContext _dbContext;
        //private readonly IDbSet<Question> _dbSet;

        //public QuestionRepository(DbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //    _dbSet = dbContext.Set<Question>();
        //}

        //public IEnumerable<ClosedAnswer> GetAllAnswerChoicesForQuestions(long id)
        //{
        //    return _dbSet.Find(id).a
        //}



        //#region IDispose members

        //private bool _disposed = false;

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!_disposed)
        //    {
        //        if (disposing)
        //        {
        //            _dbContext.Dispose();
        //        }
        //    }

        //    _disposed = true;
        //}

        //#endregion
    //}
}
