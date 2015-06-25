
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ExamDomain.Model;
using Shared.Repository;


namespace E_xam.MVCWebUI.Controllers
{
    
    public class ExamsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IRepository<Exam> _examsRepository;
        private readonly IRepository<Course> _coursesRepository;
        private readonly IRepository<Question> _questionsRepository;

        public ExamsController()
        {
            _dbContext = new ApplicationDbContext();

            _examsRepository = new Repository<Exam>(_dbContext);
            _coursesRepository = new Repository<Course>(_dbContext);
            _questionsRepository = new Repository<Question>(_dbContext);
        }

        // GET: Exams
        [Authorize(Roles = "Student,Teacher")]
        public ActionResult Index()
        {
            //IEnumerable<Exam> exams = new List<Exam>();

            //try
            //{
                var exams = _examsRepository.GetAll().ToList();
            //}
            //catch (System.Data.DataException e)
            //{
            //    var innerException = e.InnerException as DbEntityValidationException;

            //    foreach (var eve in innerException.EntityValidationErrors)
            //    {
            //        foreach (var ve in eve.ValidationErrors)
            //        {
                        
            //        }
            //    }
            //}

           

            IEnumerable<ExamViewModel> examViewModels = exams.Select(exam => new ExamViewModel(exam)).ToList();
           
            return View(examViewModels);
        }


        // GET: Exams/Details/5
        [Authorize(Roles = "Teacher")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var exam = _examsRepository.GetById(id.Value);

            if (exam == null)
            {
                return HttpNotFound();
            }

            exam.Course = _coursesRepository.GetById(exam.CourseID);
            var examViewModel = new ExamViewModel(exam);

            return View(examViewModel);
        }


        // GET: Exams/Create
        [Authorize(Roles = "Teacher")]
        public ActionResult Create()
        {

            var examViewModel = new ExamViewModel
            {
                Date = DateTime.Now,
                Time = DateTime.Now.TimeOfDay,
                Duration = new TimeSpan(1, 0, 0),
                AvailableCourses =
                    _coursesRepository.GetAll().ToDictionary(c => c.ID, c => c.Name)
            };


            return View(examViewModel);
        }


        // POST: Exams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public ActionResult Create([Bind(Include = "ID,Name,CourseID,Date,Time,Duration,Place")] ExamViewModel examViewModel)
        {
            if (ModelState.IsValid)
            {
                var exam = new Exam(examViewModel);

                _examsRepository.Add(exam);

                return RedirectToAction("Index");
            }

            return View(examViewModel);
        }


        // GET: Exams/Edit/5
        [Authorize(Roles = "Teacher")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var exam = _examsRepository.GetById(id.Value);
            
            if (exam == null)
            {
                return HttpNotFound();
            }

            var examViewModel = new ExamViewModel(exam)
            {
                AvailableCourses = _coursesRepository.GetAll().ToDictionary(c => c.ID, c => c.Name)
            };

            //exam.Questions = .Find(a => a.ClosedQuestionID == closedQuestion.ID).ToList();

            return View(examViewModel);
        }


        // POST: Exams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public ActionResult Edit([Bind(Include = "ID,Name,CourseID,Date,Time,Duration,Place,QuestionViewModels")] ExamViewModel examViewModel)
        {
            if (ModelState.IsValid)
            {
                var exam = new Exam(examViewModel);

                foreach (var questionViewModel in examViewModel.QuestionViewModels)
                {
                    if (questionViewModel.ToBeDeleted)
                    {
                        //question is not deleted - just its exam column is "cleared"
                        Question question =
                            _questionsRepository.Find(q => q.ID == questionViewModel.ID).FirstOrDefault();
                        
                        question.Exam = null;
                        question.ExamID = null;

                        //exam.Questions.RemoveAll(q => q.ID == question.ID);
                        

                        _questionsRepository.Update(question);

                    }
                    //added question
                    else if (questionViewModel.ExamID == 0)
                    {
                        Question question = new Question(questionViewModel);
                        //question.ExamID 
                    }
                }

                //_examsRepository.Update(exam);


                examViewModel.QuestionViewModels.RemoveAll(q => q.ToBeDeleted == true);
                examViewModel.Course = _coursesRepository.GetById(exam.CourseID);

                return View("Details", examViewModel);
            }

            return View(examViewModel);
        }


        // GET: Exams/Delete/5
        [HttpGet]
        [Authorize(Roles = "Teacher")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Exam exam = _examsRepository.GetById(id.Value);
            if (exam == null)
            {
                return HttpNotFound();
            }

            var examViewModel = new ExamViewModel(exam);

            return View(examViewModel);
        }


        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public ActionResult DeleteConfirmed(int id)
        {
            _examsRepository.Delete(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _examsRepository.Dispose();
            _coursesRepository.Dispose();

            base.Dispose(disposing);
        }
    }
}
