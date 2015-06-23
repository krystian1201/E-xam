
using System;
using System.Collections.Generic;
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
        

        public ExamsController()
        {
            _dbContext = new ApplicationDbContext();

            _examsRepository = new Repository<Exam>(_dbContext);
            _coursesRepository = new Repository<Course>(_dbContext);
        }

        // GET: Exams
        //[Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var exams = _examsRepository.GetAll().ToList();

            IEnumerable<ExamViewModel> examViewModels = exams.Select(exam => new ExamViewModel(exam)).ToList();
           
            return View(examViewModels);
        }


        // GET: Exams/Details/5
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

            return View(examViewModel);
        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,CourseID,Date,Time,Duration,Place")] ExamViewModel examViewModel)
        {
            if (ModelState.IsValid)
            {
                var exam = new Exam(examViewModel);

                _examsRepository.Update(exam);

                examViewModel.Course = _coursesRepository.GetById(exam.CourseID);

                return View("Details", examViewModel);
            }

            return View(examViewModel);
        }

        // GET: Exams/Delete/5
        [HttpGet]
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

            return View(exam);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _examsRepository.Delete(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _examsRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
